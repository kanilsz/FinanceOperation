using AutoMapper.Extensions.MappingProfile;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceOperation.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        _ = services
            .AddMediatR(typeof(DependencyInjection).Assembly)
            .AddMappingProfiles();
        return services;
    }
}
