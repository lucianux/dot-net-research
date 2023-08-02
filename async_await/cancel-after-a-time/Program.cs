using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Cancel
{
    public class Program
    {
        private static readonly CancellationTokenSource s_cts = new CancellationTokenSource();

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

        public static async Task Main(string[] args)
        {
            Console.WriteLine("In this example, the statement \"CancelAfter\" is shown");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey();

            try
            {
                s_cts.CancelAfter(3500);

                await SumPageSizesAsync();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nTasks cancelled: timed out.\n");
            }
            finally
            {
                s_cts.Dispose();
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to finish...");
            Console.ReadKey();
        }

        private static async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (string url in s_urlList)
            {
                int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
                total += contentLength;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }

        private static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync(token);
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }

    }
}