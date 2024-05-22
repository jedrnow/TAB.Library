using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TAB.Library.Backend.Application.Health;
using TAB.Library.Backend.Application.Middlewares;
using TAB.Library.Backend.Core;
using TAB.Library.Backend.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Unable to get connection string \"DefaultConnection\"");

builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("Database");
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString,
    options =>
    {
        options.MigrationsAssembly("TAB.Library.Backend.Infrastructure");
        options.EnableRetryOnFailure(maxRetryCount: 40, maxRetryDelay: TimeSpan.FromSeconds(15), errorNumbersToAdd: null);
    }));
builder.Services.AddInfrastructure();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "TAB.Library.Session";
    options.IdleTimeout = TimeSpan.FromDays(5);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Name = "TAB.Library.Authentication";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.Cookie.IsEssential = true;
    options.SlidingExpiration = true;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
    options.LoginPath = "/";
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TAB Library API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllHeaders");
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.UseSession();
app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/_health");

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
