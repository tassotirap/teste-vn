namespace ViajaNet.WebAccess.Presentation
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using ViajaNet.WebAccess.Domain.Core.Bus;
    using ViajaNet.WebAccess.Domain.Events;
    using ViajaNet.WebAccess.IoC;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();

            services.AddOptions();
            
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var subscriber = serviceProvider.GetService<IEventSubscriber<WebAccessRegister>>();
            var webAccessRegisters = serviceProvider.GetServices<IEventRecived<WebAccessRegister>>();
            subscriber.Subscribe(webAccessRegisters);
        }
    }
}
