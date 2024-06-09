using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Projetos.RabbitMQ.Client.Workers.Configuration
{
    public static class RabbitMQClientConfiguration
    {
        public static IServiceCollection AddRabbitMQClientWorkers(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}