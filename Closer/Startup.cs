﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Closer.DataService;
using Closer.DataService.EF;
using Closer.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Closer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<CloserContext>(opt => 
                opt.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddTransient<IDataService<User>>(x => 
                new UserDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<IDataService<Discussion>>(x =>
                new DiscussionDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<ISingleDataService<UserDiscussion>>(x => 
                new UserDiscussionDataService(services.BuildServiceProvider().GetService<CloserContext>()));
            services.AddTransient<IDataService<Message>>(x =>
                new MessageDataService(services.BuildServiceProvider().GetService<CloserContext>()));

            //var service = services.BuildServiceProvider().GetService<IDataService<User>>();
            //await service.CreateItemAsync(new User { Name = "Rea Mera", Password = "1230aaa" });

            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
