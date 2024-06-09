namespace Projetos.RabbitMQ.WebAPI.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWorkers(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddProducer(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}