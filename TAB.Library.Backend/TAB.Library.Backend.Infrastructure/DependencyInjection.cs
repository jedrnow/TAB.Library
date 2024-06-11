using Microsoft.Extensions.DependencyInjection;
using TAB.Library.Backend.Infrastructure.Repositories;
using TAB.Library.Backend.Infrastructure.Services;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;

namespace TAB.Library.Backend.Core
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookFileRepository, BookFileRepository>();
            services.AddScoped<IBookThumbnailRepository, BookThumbnailRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookThumbnailService, BookThumbnailService>();
            services.AddScoped<IBookFileService, BookFileService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
