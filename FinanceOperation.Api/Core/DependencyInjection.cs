using AutoMapper.Extensions.MappingProfile;
using MediatR;

namespace FinanceOperation.Api.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        _ = services
            .AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly))
            .AddMappingProfiles();
        return services;
    }
}
