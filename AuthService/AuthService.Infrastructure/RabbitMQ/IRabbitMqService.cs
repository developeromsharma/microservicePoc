using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.RabbitMQ
{
    public interface IRabbitMqService
    {
        Task SendMessageAsync(string queueName, object message);
    }
}
