namespace Projetos.RabbitMQ.Commons.Events
{
    public record UserCreatedEvent(
        long Id,
        string UserName,
        string Password,
        DateTimeOffset CreatedAt);
}