using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TAB.Library.Backend.Core;
using TAB.Library.Backend.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Unable to get connection string \"DefaultConnection\"");

builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("TAB.Library.Backend.Infrastructure")));
builder.Services.AddCore();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TAB Library API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
