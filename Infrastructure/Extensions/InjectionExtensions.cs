using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("Client", client =>
            {
                client.BaseAddress = new Uri("https://api.escuelajs.co");
            });

            return services;
        }
    }
}
