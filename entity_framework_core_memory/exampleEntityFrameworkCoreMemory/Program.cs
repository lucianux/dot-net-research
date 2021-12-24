using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using exampleEntityFrameworkCoreMemory.DataContext;
using exampleEntityFrameworkCoreMemory.DataContext.Data;
using Microsoft.Extensions.DependencyInjection;

namespace exampleEntityFrameworkCoreMemory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {                
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                DbInitializer.Initialize(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
