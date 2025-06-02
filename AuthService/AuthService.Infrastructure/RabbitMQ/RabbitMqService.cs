using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
        {
            var factory = new ConnectionFactory()
            {
                Uri = new System.Uri("amqp://guest:guest@localhost:5672/")
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task SendMessageAsync(string queueName, object message)
        {
            _channel.QueueDeclare(queue: queueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: "",
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: body);

            return Task.CompletedTask;
        }
    }
}
