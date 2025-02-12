using Application;
using Domain;
using Infrastructure;

namespace Web.Api
{
    public static class WebApiDependencyInjection
    {
        public static IServiceCollection AddWebApiDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI();

            services.AddDomainDi(configuration);

            services.AddInfrastructureDI();

            return services;
        }
    }
}
