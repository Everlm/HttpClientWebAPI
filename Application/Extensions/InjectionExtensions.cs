﻿using Application.ApplicationServices.Category;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
         
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryApplication, CategoryApplication>();
          
            return services;
        }
    }
}
