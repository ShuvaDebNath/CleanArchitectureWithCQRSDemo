using CRUD.Application.Handler.CommandHandlers.ClientCommandHandlers;
using CRUD.Application.Response;
using CRUD.Core.Repositories.Command.Base;
using CRUD.Core.Repositories.Query;
using CRUD.Core.Repositories.Query.Base;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Repositories.Command;
using CRUD.Infrastructure.Repositories.Command.Base;
using CRUD.Infrastructure.Repositories.Query;
using CRUD.Infrastructure.Repositories.Query.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRUD.API
{
    public static class StartupServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureSqlDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ModelContext>(options => options.UseSqlServer(config.GetConnectionString("CrudDBConnection")));
          
        }

        public static void ConfigureDipendencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(CreateClientHandler).GetTypeInfo().Assembly);
         
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<IClientQueryRepository, ClientQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<Core.Repositories.Command.IClientCommandRepository, ClientCommandRepository>();
            
        }
    }
}
