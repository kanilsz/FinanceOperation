using AutoMapper.Extensions.MappingProfile;

namespace FinanceOperation.Api.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly))
            .AddMappingProfiles();

        return services;
    }
}
