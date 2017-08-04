using LunoApi.Net.Accounts;
using LunoApi.Net.Common;
using LunoApi.Net.MarketData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net
{
    public sealed class LunoApi
    {
        public IMarketData MarketData { get; private set; }
        public IAccounts Accounts { get; private set; }
        public LunoApi(IConfig lunoConfig)
        {
            var lunoApiClient = new LunoApiClient(lunoConfig);
            MarketData = new MarketData.MarketData(lunoApiClient);
            Accounts = new Accounts.Accounts(lunoApiClient);
        }
    }
}
