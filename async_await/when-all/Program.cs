using System.Diagnostics;

namespace ProcessTasksAsTheyFinish;

public class Program
{
    public async static Task Main(string[] args)
    {
        Console.WriteLine("In this example, the statement \"When All\" is shown");
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey();

        await SimpleParallelWriteAsync();

        Console.WriteLine("A folder titled \"tempfolder\" was created");
        Console.WriteLine("Press any key to finish...");
        Console.ReadKey();
    }

    public static async Task SimpleParallelWriteAsync()
    {
        string folder = Directory.CreateDirectory("tempfolder").Name;
        IList<Task> taskCollection = new List<Task>();
        Task task;

        for (int index = 1; index <= 10; index++)
        {
            string fileName = $"file-{index:00}.txt";
            string filePath = $"{folder}/{fileName}";
            string content = $"In file {index}{Environment.NewLine}";

            task = File.WriteAllTextAsync(filePath, content);
            taskCollection.Add(task);
        }

        await Task.WhenAll(taskCollection);
    }
}
