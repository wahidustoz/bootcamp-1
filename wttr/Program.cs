using System;
using System.Net.Http;
var addr = "https://wttr.in";
var query = "/tashkent?format=3";

using var client = new HttpClient()
{
    BaseAddress = new System.Uri(addr)
};
Console.WriteLine(client.GetStringAsync(query).Result);
