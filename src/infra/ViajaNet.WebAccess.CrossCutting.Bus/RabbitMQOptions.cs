namespace ViajaNet.WebAccess.CrossCutting.Bus
{
    public class RabbitMQOptions
    {
        public string HostName { get; set; }

        public string Exchange { get; set; }

        public string QueueName { get; set; }
    }
}
