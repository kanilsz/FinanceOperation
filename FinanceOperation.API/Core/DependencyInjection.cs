using MediatR;

namespace FinanceOperation.API.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore (this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(DependencyInjection).Assembly);
            //.AddAutoMapper(typeof(MappingProfile).Assembly);//TODO: Should be implemented
            return services;
        }
    }
}
