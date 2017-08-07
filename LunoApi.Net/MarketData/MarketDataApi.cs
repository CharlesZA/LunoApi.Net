using LunoApi.Net.Common;
using LunoApi.Net.MarketData.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.MarketData
{
    public class MarketDataApi : IMarketDataApi
    {
        private LunoApiClient _lunoAPIClient { get; set; }

        internal MarketDataApi(LunoApiClient webClient)
        {
            _lunoAPIClient = webClient;
        }
        public async Task<ITicker> GetTicker(string pair)
        {
            var data = await _lunoAPIClient.GetPublicData<Ticker>("ticker", "pair=" + pair);
            return data;
        }
    }
}
