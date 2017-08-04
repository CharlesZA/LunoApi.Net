using System;
using LunoApi;
using LunoApi.Net.Common;
using Newtonsoft.Json;

namespace LunoApi.Net.Demo
{
    class Program
    {
        private static LunoApi lunoAPI { get; set; }
        static void Main(string[] args)
        {
            IConfig lunoConfig = new LunoConfig() { ID = "", Secret = "", PublicAPI = "https://api.mybitx.com/api/1/", PrivateAPI = "" };
            lunoAPI = new LunoApi(lunoConfig);
            GetTicker();
            Console.ReadLine();
        }


        private static async void GetTicker()
        {
            var result = await lunoAPI.MarketData.GetTicker("XBTZAR");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}