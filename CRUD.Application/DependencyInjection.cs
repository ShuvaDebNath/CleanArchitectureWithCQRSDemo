using CRUD.Application.Common.Behaviours;
using CRUD.Application.Common.MVC;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembles = GetAssemblies();
            services.AddAutoMapper(assembles);
            services.ConfigureCors();
            services.AddMediator(assembles);
            services.AddValidation(assembles);
            services.AddControllers(option => option.Filters.Add<ExceptionFilter>());

            return services;
        }

        private static Assembly[] GetAssemblies()
        {
            return new Assembly[] 
            {
                Assembly.GetExecutingAssembly(),
                Assembly.GetCallingAssembly(),
                typeof(DependencyInjection).Assembly,
            };

        }

        private static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;
        }

        private static  IServiceCollection AddMediator(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);
            return services;
        }


    }
}
