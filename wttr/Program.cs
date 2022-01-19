using System;
using System.Net.Http;

using var client = new HttpClient() { BaseAddress = new Uri("https://wttr.in") };
Console.WriteLine(client.GetStringAsync("/tashkent?format=3").Result);

