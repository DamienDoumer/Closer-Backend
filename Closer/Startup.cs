using System;
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
            //var service2 = services.BuildServiceProvider().GetService<IDataService<Discussion>>();
            //var service1 = services.BuildServiceProvider().GetService<ISingleDataService<UserDiscussion>>();

            //await service.CreateItemAsync(new User { Name = "Rea Mera", Password = "1230aaa" });
            //await service.CreateItemAsync(new User { Name = "Hera", Password = "456" });
            //await service.CreateItemAsync(new User { Name = "Shababo", Password = "78ds" });

            //await service2.CreateItemAsync(new Discussion { Title = "First Discussion",
            //    Description = "Initial discussion only", DiscussionUserCreatorId = 2 });
            //await service2.CreateItemAsync(new Discussion { Title = "Second Discussion",
            //    Description = "Second discussion only", DiscussionUserCreatorId = 4 });

            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 1, UserId = 3 });
            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 1, UserId = 1 });
            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 1, UserId = 5 });
            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 2, UserId = 3 });
            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 1, UserId = 2 });
            //await service1.CreateItemAsync(new UserDiscussion { DiscussionId = 2, UserId = 1 });

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
