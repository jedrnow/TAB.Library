﻿using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}