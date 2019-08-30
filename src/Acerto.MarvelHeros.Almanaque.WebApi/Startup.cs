using Acerto.MarvelHeros.Almanaque.GoogleTradutorAdapter;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Acerto.MarvelHeros.Almanaque.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var marvelApiAdapterConfiguration = Configuration.TryGet<MarvelApiAdapterConfiguration>();
            var googleTradutorAdapterConfiguration = Configuration.TryGet<GoogleTradutorAdapterConfiguration>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Acerto Almanaque", Version = "v1" });

                //Set the comments path for the Swagger JSON and UI.

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Configurações de Log
            services.AddLogging(conf =>
            {
                conf.ClearProviders();

                var loggerConfiguration = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("System", LogEventLevel.Error)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .MinimumLevel.Override("Default", LogEventLevel.Information);

                loggerConfiguration = loggerConfiguration.Enrich.FromLogContext();

                //File
                loggerConfiguration = loggerConfiguration.WriteTo.Async(a => a.File($"Logs/log-.txt"));

                //Sql Server
                var tableName = "Logs";
                var columnOption = new ColumnOptions();
                columnOption.Store.Remove(StandardColumn.MessageTemplate);
                loggerConfiguration.WriteTo.MSSqlServer(Configuration.GetConnectionString("LoggerDatabase"), tableName, columnOptions: columnOption);

                Log.Logger = loggerConfiguration.CreateLogger();
                conf.AddSerilog();
            });

            //Injeçoes de Dependência dos Projetos de Infra
            services.AddMd5Encode();
            services.AddGoogleTradutorAdapter(googleTradutorAdapterConfiguration);
            services.AddMarvelApiAdapter(marvelApiAdapterConfiguration);
            services.AddAlmanaque();

            Mapper.Initialize(config =>
            {
                config.AddProfile<MarvelApiAdapterConfigurationAutoMapperProfile>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acerto Almanaque V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection(); //Força HTTPS
            app.UseMvc();
        }
    }
}