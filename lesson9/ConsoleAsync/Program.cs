using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace ConsoleAsync
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Console.WriteLine($"Boshladi");
            var request = DownloadUserAsync();
            Console.WriteLine($"Chaqirib boldi: {request.Result}");
            Console.ReadKey();
        }
    }
}
