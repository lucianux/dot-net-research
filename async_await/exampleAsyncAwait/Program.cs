using System;
using System.Threading;
using System.Threading.Tasks;

namespace exampleAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(
                async () => 
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("The Beginning");
                    await Robot.LongProcess();
                    Robot.ShortProcess();
                    Console.WriteLine("The End");
                }
            );
        }
    }

    public class Robot
    {
        public static async Task LongProcess()
        {
            Console.WriteLine("LongProcess - It has started");
            //Thread.Sleep(5000);
            await Task.Delay(5000);
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
