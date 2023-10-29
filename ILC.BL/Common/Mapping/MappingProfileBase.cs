using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Common.Mapping
{
    public class MappingProfileBase : Profile
    {
        public MappingProfileBase()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public MappingProfileBase(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            MapFromTypes(assembly);
            MapToTypes(assembly);
        }

        private void MapFromTypes(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                   .Where(t => t.GetInterfaces().Any(i =>
                       i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                   .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("MapFrom") ?? type.GetInterface(typeof(IMapFrom<>).Name).GetMethod("MapFrom");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        private void MapToTypes(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("MapTo") ?? type.GetInterface(typeof(IMapTo<>).Name).GetMethod("MapTo");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
