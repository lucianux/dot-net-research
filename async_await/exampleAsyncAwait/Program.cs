using System;
using System.Threading;
using System.Threading.Tasks;

namespace exampleAsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(1000);
            Console.WriteLine("The Beginning");
            Task TLongProcess = Robot.LongProcessAsync();

            Robot.ShortProcess();
            await TLongProcess;

            Console.WriteLine("The End");
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

        public static void ShortProcess()
        {
            Console.WriteLine("ShortProcess - It has started");
            Thread.Sleep(1000);
            Console.WriteLine("ShortProcess - It has finished");
        }
    }
}
