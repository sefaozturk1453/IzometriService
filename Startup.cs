using AutoMapper;
using IzometriService.Business.Helpers.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;
using Autofac.Core;
using Autofac;
using IzometriService.Business.Concrete.API;
using IzometriService.Business.Abstract.API;
using IzometriService.Business.DependencyResolvers.Autofac.API;
using IzometriService.Core.Extensions;


namespace IzometriService
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
            services.AddControllers();
            //services.AddAutoMapper(typeof(AutoMapperHelper));


            services.AddSwaggerGen(
               gen =>
                {
                        gen.SwaggerDoc("WebAPI_V1", new OpenApiInfo
                        {
                            Version = "V1",
                            Title = "Izometri_V1",
                            Description = "Izometri_Dot_Net_3_1",
                            Contact = new OpenApiContact
                            {
                                Name = "Sefa Ozturk",
                                Email = "sefaozturk1992@gmail.com"
                            }
                        });
                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                        gen.IncludeXmlComments(xmlPath);
                }

            );


            // Microsoft.AspNetCore.Mvc.NewtonsoftJson 
            // fixed for System.Text.Json.JsonException: 
            // A possible object cycle was detected which is not supported. 
            // This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32. at
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

          

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/WebAPI_V1/swagger.json", "IzometriApi v1");
            });



            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModuleAPI());
        }
    }
}
