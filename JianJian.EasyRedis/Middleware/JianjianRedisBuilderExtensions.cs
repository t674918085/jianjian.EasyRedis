using JianJian.EasyRedis.Base;
using JianJian.EasyRedis.Base.Interface;
using JianJian.EasyRedis.Base.Service;
using JianJian.EasyRedis.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JianJian.EasyRedis.Middleware
{
    public static class JianjianRedisBuilderExtensions
    {
       
        /// <summary>
        /// Adds the default redis cache.
        /// </summary>
        /// <returns>The default redis cache.</returns>
        /// <param name="services">Services.</param>
        /// <param name="optionsAction">Options Action.</param>
        public static IServiceCollection AddJianjianRedisCache(this IServiceCollection services, Action<RedisCacheOptions> optionsAction)
        {
            ArgumentCheck.NotNull(services, nameof(services));
            ArgumentCheck.NotNull(optionsAction, nameof(optionsAction));

            services.AddOptions();
            services.Configure(optionsAction);
           // services.TryAddSingleton<IEasyCachingSerializer, DefaultBinaryFormatterSerializer>();
            services.TryAddSingleton<IRedisDatabaseProvider, RedisDatabaseProvider>();
            services.TryAddSingleton<IJianjianEasyCachingProvider, JianjianEasyCachingProvider>();

            return services;
        }
    }
}
