namespace ViajaNet.WebAccess.IoC
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using ViajaNet.WebAccess.Application.AutoMapper;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.Services;
    using ViajaNet.WebAccess.CrossCutting.Bus;
    using ViajaNet.WebAccess.Data.Options;
    using ViajaNet.WebAccess.Data.Repositories;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.EventHandlers;
    using ViajaNet.WebAccess.Domain.Events;
    using ViajaNet.WebAccess.Domain.Repositories;
    using Microsoft.Extensions.Configuration;
    using ViajaNet.WebAccess.Domain.Services.Interfaces;
    using ViajaNet.WebAccess.Domain.Services;

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));
            services.AddSingleton<IEventEmitter<WebAccessRegister>, RabbitMQEventEmitter<WebAccessRegister>>();
            services.AddSingleton<IEventSubscriber<WebAccessRegister>, RabbitMQEventSubscriber<WebAccessRegister>>();

            services.AddSingleton<IEventRecived<WebAccessRegister>, WebAccessEventHandler>();

            services.Configure<CouchbaseOptions>(configuration.GetSection("Couchbase"));
            services.AddSingleton<IWebAccessRepository, WebAccessRepository>();            

            services.AddSingleton<IMapper>(sp => new Mapper(AutoMapperConfig.RegisterMappings()));

            services.AddSingleton<IWebAccessService, WebAccessService>();

            services.AddScoped<IWebAccessAppService, WebAccessAppService>();

            
        }
    }
}
