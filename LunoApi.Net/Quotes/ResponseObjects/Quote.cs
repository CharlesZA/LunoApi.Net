using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Quotes.ResponseObjects
{
    public class Quote: IQuote
    {
        [JsonProperty("id")]
        public int QuoteID { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("pair")]
        public string CurrencyPair { get; set; }
        [JsonProperty("base_amount")]
        public double BaseAmount { get; set; }
        [JsonProperty("counter_amount")]
        public double CounterAmount { get; set; }
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
        [JsonProperty("discarded")]
        public bool Discarded { get; set; }
        [JsonProperty("exercised")]
        public bool Exercised { get; set; }
    }
}
