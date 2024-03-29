﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WildPaws.Core.Contracts;
using WildPaws.Core.Services;
using WildPaws.Infrastructure.Data;
using WildPaws.Infrastructure.Data.Identity;
using WildPaws.Infrastructure.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuestionnareService, QuestionnaireService>();
            services.AddScoped<IFormulaCalculationService, FormulaCalculationService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = configuration.GetValue<string>("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();


            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<WildPawsUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            return services;
        }

    }
}
