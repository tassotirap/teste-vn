namespace ViajaNet.WebAccess.CrossCutting.Bus
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Core.Events;


    public class RabbitMQEventSubscriber<T> :
        IEventSubscriber<T>,
        IDisposable
        where T : Event
    {
        private IConnection connection;
        private IModel channel;

        private IList<IEventRecived<T>> listEventRecived;
        private readonly IOptions<RabbitMQOptions> options;

        public RabbitMQEventSubscriber(IOptions<RabbitMQOptions> options)
        {
            this.listEventRecived = new List<IEventRecived<T>>();
            this.options = options;

            if (options.Value.ConsumerEnabled)
            {
                this.CreateChannel();
                this.CreateConsumer();
            }
        }

        public void Dispose()
        {
            this.channel?.Dispose();
            this.connection?.Dispose();
        }

        public void Subscribe(IEventRecived<T> eventRecived)
        {
            this.listEventRecived.Add(eventRecived);
        }

        public void Subscribe(IEnumerable<IEventRecived<T>> eventReciveds)
        {
            foreach(var eventRecived in eventReciveds)
            {
                this.Subscribe(eventRecived);
            }
        }

        private void CreateChannel()
        {
            this.connection = new ConnectionFactory()
            {
                HostName = this.options.Value.HostName,
                DispatchConsumersAsync = true
            }.CreateConnection();

            this.channel = connection.CreateModel();
        }

        private void CreateConsumer()
        {
            this.channel.ExchangeDeclare(this.options.Value.Exchange, ExchangeType.Direct);

            this.channel.QueueDeclare(this.options.Value.QueueName, true, false, false, null);

            this.channel.QueueBind(this.options.Value.QueueName, this.options.Value.Exchange, string.Empty, null);

            this.channel.BasicQos(0, 100, false);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (ch, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body);

                var @object = JsonConvert.DeserializeObject<T>(body);

                foreach (var eventRecived in listEventRecived)
                {
                    await eventRecived.EventRecived(@object);
                }

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(this.options.Value.QueueName, false, consumer);
        }
    }
}
