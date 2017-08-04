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
            IConfig lunoConfig = new LunoConfig() { ID = "API_ID", Secret = "API_SECRET", PublicAPIUrl = "https://api.mybitx.com/api/1/" };
            lunoAPI = new LunoApi(lunoConfig);
            GetTicker();
            GetBalance();
            Console.ReadLine();
        }


        private static async void GetTicker()
        {
            var result = await lunoAPI.MarketData.GetTicker("XBTZAR");
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        private static async void GetBalance()
        {
            var result = await lunoAPI.Accounts.GetBalance();
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}