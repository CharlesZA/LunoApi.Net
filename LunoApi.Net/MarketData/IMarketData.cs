using LunoApi.Net.MarketData.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.MarketData
{
    public interface IMarketData
    {
        Task<ITicker> GetTicker(string pair);
    }
}
