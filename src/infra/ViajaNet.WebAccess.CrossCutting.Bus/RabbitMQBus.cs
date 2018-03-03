namespace ViajaNet.WebAccess.CrossCutting.Bus
{
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Core.Events;


    public class RabbitMQBus<T> :
        IEventHandler<T>,
        IDisposable
        where T : Event
    {
        private readonly IConnection connection;

        private readonly IModel channel;

        private readonly string exchange;

        public RabbitMQBus(string exchange, string queueName)
        {
            this.connection = new ConnectionFactory()
            {
                HostName = "localhost"
            }.CreateConnection();

            this.channel = connection.CreateModel();

            this.channel.ExchangeDeclare(exchange, ExchangeType.Direct);
            this.channel.QueueDeclare(queueName, false, false, false, null);
            this.channel.QueueBind(queueName, exchange, string.Empty, null);
            this.exchange = exchange;
        }

        public void Dispose()
        {
            this.channel?.Dispose();
            this.connection?.Dispose();
        }

        public async Task RaiseEvent(T @event)
        {
            var jsonObject = JsonConvert.SerializeObject(@event);

            var body = Encoding.UTF8.GetBytes(jsonObject);

            await Task.Run(() => channel.BasicPublish(exchange, string.Empty, null, body));
        }
    }
}
