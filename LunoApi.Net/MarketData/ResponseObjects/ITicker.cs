using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.MarketData.ResponseObjects
{
    public interface ITicker
    {
        long TimeStamp { get; }
        double Ask { get; }
        double Bid { get; }
        double LastTrade { get; }
        double Rolling24HVolume { get; }
        string Pair { get; }
    }
}
