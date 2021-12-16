using AutoMapper;
using System.Linq;
using System.Reflection;

namespace FinanceOperation.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFrom(Assembly.GetEntryAssembly());
            ApplyMappingsTo(Assembly.GetEntryAssembly());
        }

        private void ApplyMappingsTo(Assembly? assembly)
        {
            IEnumerable<Type> innerTypes = assembly.DefinedTypes
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)));

            IEnumerable<Type> outerTypes = assembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(types => types.DefinedTypes)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)));

            foreach (Type type in innerTypes.Concat(outerTypes))
            {
                var instance = Activator.CreateInstance(type);

                MethodInfo? methodInfo = type.GetMethod("MapTo")
                    ?? type.GetInterface("IMapTo`base")?.GetMethod("MapTo");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        private void ApplyMappingsFrom(Assembly? assembly)
        {
            IEnumerable<Type> innerTypes = assembly.DefinedTypes
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)));

            IEnumerable<Type> outerTypes = assembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(types => types.DefinedTypes)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)));

            foreach (Type type in innerTypes.Concat(outerTypes))
            {
                var instance = Activator.CreateInstance(type);

                MethodInfo? methodInfo = type.GetMethod("MapFrom")
                    ?? type.GetInterface("IMapFrom`base")?.GetMethod("MapFrom");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}