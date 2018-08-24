using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Closer.DataService;
using Closer.DataService.EF;
using Closer.Entities;
using Closer.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Closer
{
    public class Startup
    {
        public IHostingEnvironment _hostingEnvironment;
        public IConfiguration _configuration;

        public Startup(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        //This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddDbContext<CloserContext>(opt => 
                opt.UseSqlServer(_configuration["Data:DefaultConnection:ConnectionString"]));
            
            services.AddTransient<IDataService<User>>(x => 
                new UserDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<IDataService<Discussion>>(x =>
                new DiscussionDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<ISingleDataService<UserDiscussion>>(x => 
                new UserDiscussionDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<IDataService<Message>>(x =>
                new MessageDataService(services.BuildServiceProvider().GetService<CloserContext>()));
             
            services.AddMvc(opt =>
            {
                if(!_hostingEnvironment.IsProduction())
                {
                    opt.SslPort = 44382;
                }
                opt.Filters.Add(new RequireHttpsAttribute());
            })
                .AddJsonOptions(opt =>
                {
                    //The best Json serializer settings 
                    opt.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSQLServerLogger(LogLevel.Information, _configuration["Data:DefaultConnection:ConnectionString"]);
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Users}");
            });
        }
    }
}
