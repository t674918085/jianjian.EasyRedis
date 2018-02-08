using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JianJian.EasyRedis.Middleware;
using EasyCaching.Redis;
using EasyCaching.Core.Internal;

namespace TestWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddJianjianRedisCache(option =>
            {
                option.Database = 3;
                option.Endpoints.Add(new JianJian.EasyRedis.Base.ServerEndPoint("121.40.109.112", 6000));
                
            });

            //services.AddDefaultRedisCache(option =>
            //{
            //    option.Endpoints.Add(new  ServerEndPoint("121.40.109.112", 6001));
            //    option.Database = 3;
            //    option.Password = "fumasoft61279800";
            //});

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //("121.40.109.112:6000,allowadmin=true,password=fumasoft61279800", 2);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
