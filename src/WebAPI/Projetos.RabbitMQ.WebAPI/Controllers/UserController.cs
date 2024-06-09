using Microsoft.AspNetCore.Mvc;
using Projetos.RabbitMQ.Commons.Configuration;
using Projetos.RabbitMQ.Commons.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Projetos.RabbitMQ.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(
        ILogger<UserController> logger,
        IConfiguration configuration) : ControllerBase
    {
        [HttpPost("Create")]
        public IActionResult Post(string rountingKey)
        {
            try
            {
                var rabbitMqConfig = configuration.GetSection("RabbitMq").Get<RabbitMqConfig>();
                var factory = new ConnectionFactory()
                {
                    HostName = rabbitMqConfig!.Host,
                    Port = rabbitMqConfig!.Port,
                    UserName = rabbitMqConfig!.User,
                    Password = rabbitMqConfig!.Password
                };

                var message = new UserCreatedEvent(1, "André", "123456", DateTimeOffset.Now);
                var jsonMessage = JsonSerializer.Serialize(message);

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var body = Encoding.UTF8.GetBytes(jsonMessage);

                    channel.BasicPublish(
                        exchange: "exchange-teste",
                        routingKey: rountingKey,
                        basicProperties: null,
                        body: body);
                    logger.LogInformation("Mensagem enviada com sucesso. {mensagem}", jsonMessage);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao enviar mensagem.");
                throw;
            }
        }
    }
}