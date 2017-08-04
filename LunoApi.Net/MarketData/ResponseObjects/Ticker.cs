using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.MarketData.ResponseObjects
{
    public class Ticker: ITicker
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
        [JsonProperty("ask")]
        public double Ask { get; set; }
        [JsonProperty("bid")]
        public double Bid { get; set; }
        [JsonProperty("last_trade")]
        public double LastTrade { get; set; }
        [JsonProperty("rolling_24_hour_volume")]
        public double Rolling24HVolume { get; set; }
        [JsonProperty("pair")]
        public string Pair { get; set; }
    }
}
