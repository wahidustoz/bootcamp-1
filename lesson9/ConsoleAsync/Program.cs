using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace ConsoleAsync
{
    class Program
    {
        static async Task MakingTable()
        {
            Console.WriteLine($"Making table...");
            await Task.Delay(3000);
            Console.WriteLine($"Table is ready!");
        }
        static async Task MakingTea()
        {
            Console.WriteLine($"Making tea...");
            await Task.Delay(5000);
            Console.WriteLine($"Tea is ready!");
        }
        static async Task FryingEggs()
        {
            Console.WriteLine($"Frying eggs...");
            await Task.Delay(7000);
            Console.WriteLine($"Eggs are ready!");
        }

        static async Task Main()
        {
            Console.WriteLine($"Good morning");

            var tasks = new Task[] { FryingEggs(), MakingTea(), MakingTable() };

            var all = Task.WhenAll(tasks);
            await all;

            Console.WriteLine($"Bon appetito!");
        }


        static async Task<string> DownloadUserAsync()
        {
            var client = new HttpClient();

            using(HttpResponseMessage response = await client.GetAsync("https://youtu.be/Qvmp4F-hOKA"))
            {
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return $"Error Occured: {response.ReasonPhrase}";
            }
        }

        static void Main1(string[] args)
        {
            Console.WriteLine($"Boshladi");
            var request = DownloadUserAsync();
            Console.WriteLine($"Chaqirib boldi: {request.Result}");
            Console.ReadKey();
        }
    }
}
