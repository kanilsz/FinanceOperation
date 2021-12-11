using FinanceOperation.Core.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceOperation.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(DependencyInjection).Assembly)
            .AddAutoMapper(typeof(MappingProfile).Assembly);//TODO: Should be implemented
            return services;
        }
    }
}
