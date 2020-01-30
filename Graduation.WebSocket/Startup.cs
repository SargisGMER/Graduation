using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Graduation.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BetConstruct.WebSockets
{
    public class Startup
    {
        System.Timers.Timer timerSender;
        private static Uri webAPIConfig;
        public static Uri WebAPIConfig
        {
            get { return webAPIConfig; }
            private set { webAPIConfig = value; }
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            ConfigurationRoot = builder.Build();

            // create uri from appsettings.json
           

          
        }

        public IConfigurationRoot ConfigurationRoot { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketManager();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(60),
                ReceiveBufferSize = 4 * 1024,
            };

            app.UseWebSockets(wsOptions);

            app.MapWebSocketManager("/LogIn", serviceProvider.GetService<LogInHandler>());

            app.MapWebSocketManager("/Graudation", serviceProvider.GetService<ChatRoomHandler>());

            app.UseMvc();
        }
    }
}
