using System;
using Microsoft.Extensions.DependencyInjection;

namespace exampleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddScoped<IHello, Hello1>();
            services.AddScoped<IHello, Hello2>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IHello example = serviceProvider.GetService<IHello>();

            string message = example.GetMessage();
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
