using System;
using System.Linq;
using System.Threading.Tasks;
using ViajaNet.WebAccess.CrossCutting.Bus;
using ViajaNet.WebAccess.Domain.Events;
using Xunit;

namespace ViajaNet.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //var bus = new RabbitMQEventEmitter<WebAccessRegister>();

            //foreach (var i in Enumerable.Range(0, 5))
            //{
            //    await bus.Emit(new WebAccessRegister(new WebAccess.Domain.Models.WebAccess
            //    {
            //        Data = DateTime.Now,
            //        IP = "127.0.0.1",

            //    }));
            //}
        }

        [Fact]
        public async Task Test2()
        {
            //CouchbaseRepository.Connect();
        }
    }
}
