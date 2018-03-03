namespace ViajaNet.WebAccess.IoC
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using ViajaNet.WebAccess.Application.AutoMapper;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.Services;
    using ViajaNet.WebAccess.CrossCutting.Bus;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var rabbitMQBusWebAccess = new RabbitMQBus<WebAccessRegister>("WebAccessRegister", "WebAccessRegistered");

            services.AddSingleton<IEventHandler<WebAccessRegister>>(rabbitMQBusWebAccess);

            services.AddScoped<IMapper>(sp => new Mapper(AutoMapperConfig.RegisterMappings()));

            services.AddScoped<IWebAccessAppService, WebAccessAppService>();
        }
    }
}
