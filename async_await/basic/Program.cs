using System;
using System.Threading;
using System.Threading.Tasks;

namespace basic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("In this example, the mechanism \"Async/Await\" is shown");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();

            Task longProcessTask = Robot.LongProcessAsync();
            Task shortProcessTask = Robot.ShortProcess();
            
            await longProcessTask;
            await shortProcessTask;

            Console.WriteLine("Press any key to finish...");
            Console.ReadKey();
        }
    }

    public class Robot
    {
        public static async Task LongProcessAsync()
        {
            Console.WriteLine("LongProcess - It has started");
            await Task.Delay(3000);
            Console.WriteLine("LongProcess - It has finished");
        }

        public static async Task ShortProcess()
        {
            Console.WriteLine("ShortProcess - It has started");
            await Task.Delay(1000);
            Console.WriteLine("ShortProcess - It has finished");
        }
    }
}
