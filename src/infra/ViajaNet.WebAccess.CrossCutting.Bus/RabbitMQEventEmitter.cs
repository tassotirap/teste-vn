namespace ViajaNet.WebAccess.CrossCutting.Bus
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Core.Events;


    public class RabbitMQEventEmitter<T> :
        IEventEmitter<T>,
        IDisposable
        where T : Event
    {
        private IConnection connection;
        private IModel channel;

        private readonly IOptions<RabbitMQOptions> options;

        public RabbitMQEventEmitter(IOptions<RabbitMQOptions> options)
        {
            this.options = options;
            this.CreateChannel();
            this.CreateExchange();            
        }

        public void Dispose()
        {
            this.channel?.Dispose();
            this.connection?.Dispose();
        }

        public void Emit(T @event)
        {
            var jsonObject = JsonConvert.SerializeObject(@event);

            var body = Encoding.UTF8.GetBytes(jsonObject);

            channel.BasicPublish(this.options.Value.Exchange, string.Empty, null, body);
        }

        private void CreateExchange()
        {
            this.channel.ExchangeDeclare(this.options.Value.Exchange, ExchangeType.Direct);
        }

        private void CreateChannel()
        {
            this.connection = new ConnectionFactory()
            {
                HostName = this.options.Value.HostName
            }.CreateConnection();

            this.channel = connection.CreateModel();
        }

        public Task EmitAsync(T @event)
        {
            throw new NotImplementedException();
        }
    }
}
