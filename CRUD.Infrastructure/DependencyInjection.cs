using CRUD.Core.Repositories.Command.Base;
using CRUD.Core.Repositories.Query.Base;
using CRUD.Core.Repositories.Query;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Repositories.Command.Base;
using CRUD.Infrastructure.Repositories.Command;
using CRUD.Infrastructure.Repositories.Query.Base;
using CRUD.Infrastructure.Repositories.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfratructure(this IServiceCollection services, string connectionString)
        {
            var assembles = GetAssemblies();

            services.AddDatabase(connectionString);
            services.AddRepositories();
            
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

        private static IServiceCollection AddDatabase
            (this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ModelContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories
            (this IServiceCollection services)
        {
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IClientQueryRepository, ClientQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<Core.Repositories.Command.IClientCommandRepository, ClientCommandRepository>();

            return services;
        }
    }
}
