using System.Diagnostics;
using System.Collections.Generic;

public class Program
{
    private static readonly HttpClient s_client = new()
    {
        MaxResponseContentBufferSize = 1_000_000
    };

    private static IEnumerable<string> s_urlList = new string[]
    {
        "https://github.com/ardalis/CleanArchitecture/pull/580",
        "https://github.com/ardalis/CleanArchitecture/pull/579",
        "https://github.com/ardalis/CleanArchitecture/pull/578",
        "https://github.com/ardalis/CleanArchitecture/pull/576",
        "https://github.com/ardalis/CleanArchitecture/pull/575",
        "https://github.com/ardalis/CleanArchitecture/pull/573",
        "https://github.com/ardalis/CleanArchitecture/pull/571",
        "https://github.com/ardalis/CleanArchitecture/pull/556",
        "https://github.com/ardalis/CleanArchitecture/pull/551",
        "https://github.com/ardalis/CleanArchitecture/pull/548",
        "https://github.com/ardalis/CleanArchitecture/pull/532",
        "https://github.com/ardalis/CleanArchitecture/pull/382",
        "https://github.com/ardalis/CleanArchitecture/pull/528"
    };

    public async static Task Main(string[] args)
    {
        Console.WriteLine("In this example, the statement \"When Any\" is shown");
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey();

        await SumPageSizesAsync();

        Console.WriteLine("");
        Console.WriteLine("Press any key to finish...");
        Console.ReadKey();
    }

    public static async Task SumPageSizesAsync()
    {
        var stopwatch = Stopwatch.StartNew();

        List<Task<int>> downloadTasks = new List<Task<int>>();
        Task<int> task;

        foreach (var url in s_urlList) {
            task = ProcessUrlAsync(url, s_client);
            downloadTasks.Add(task);
        }

        int totalBytesDownloaded = 0;
        while (downloadTasks.Any())
        {
            Task<int> finishedTask = await Task.WhenAny(downloadTasks);
            downloadTasks.Remove(finishedTask);
            totalBytesDownloaded += await finishedTask;
        }

        stopwatch.Stop();

        Console.WriteLine($"\nTotal bytes returned:    {totalBytesDownloaded:#,#}");
        Console.WriteLine($"Elapsed time:              {stopwatch.Elapsed}\n");
    }

    public static async Task<int> ProcessUrlAsync(string url, HttpClient client)
    {
        byte[] content = await client.GetByteArrayAsync(url);
        Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

        return content.Length;
    }
}