using AutoMapper;
using CRUD.Application.Commands.ClientCommands;
using CRUD.Application.Response;
using CRUD.Core.Common;
using CRUD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Mapper
{
    public class MappingProfile : Profile
    {
        private const string MethodName = "Mapping";
        private const string MapFromName = "IMapFrom";
        private const string MapToName = "IMapTo";

        public MappingProfile()
        {
            var domainAssembly = typeof(CRUD.Core.DependencyInjection).Assembly;
            ApplyMappingsFromAssembly(
                Assembly.GetExecutingAssembly(),
                Assembly.GetCallingAssembly(),
                domainAssembly);
        }

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            var exportedTypes = assemblies.SelectMany(a => a.GetExportedTypes());
            var iMapFromTypes = exportedTypes
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();
            var iMapToTypes = exportedTypes
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
            .ToList();

            Map(iMapFromTypes, MapFromName);
            Map(iMapToTypes, MapToName);
        }

        private void Map(IEnumerable<Type> types, string interfaceName)
        {
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfos = type
                                .GetInterfaces()
                                .Where(i => i.Name.StartsWith($"{interfaceName}`1"))
                                .Select(i => i.GetMethod(MethodName));
                methodInfos.ToList().ForEach(methodInfo =>
                {
                    methodInfo?.Invoke(instance, new object[] { this });
                });
            }
        }
    }
}
