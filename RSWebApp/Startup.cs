using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace RSWebApp
{
    public class Startup
    {
        ILogger<Startup> logger;
       
        public Startup(IConfiguration configuration)//pushing trial!!! good-luck
        {
                                                    
            Configuration = configuration;
            

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SignContext>(option => option.UseSqlServer
            ("Data Source=srv2\\pupils; initial catalog=sign;Integrated Security=True;Pooling=False"));
            services.AddControllers();
            //services.AddTransient<IManagerDL,ManagerDL>();
            //services.AddTransient<IManagerBL, ManagerBL>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IManagerBL), typeof(ManagerBL));
            services.AddScoped(typeof(IManagerDL), typeof(ManagerDL));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RSWebApp", Version = "v1" });
            });
            services.AddResponseCaching();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup>logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RSWebApp v1"));
                this.logger = logger;
                try { 
            logger.LogInformation("startup is up?");
            }
            catch (Exception Ex){ logger.LogError(Ex.Message);}
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
