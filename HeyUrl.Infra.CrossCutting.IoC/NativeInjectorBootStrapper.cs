using HeyUrl.Domain.Interfaces;
using HeyUrl.Infra.Data.Context;
using HeyUrl.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HeyUrl.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandler, InMemoryBus>();



            // Infra - Data
            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddScoped<HeyUrlContext>();


        }
    }
}
