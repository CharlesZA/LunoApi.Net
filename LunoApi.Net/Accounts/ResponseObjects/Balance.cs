using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Accounts.ResponseObjects
{
    public class Balance
    {
        [JsonProperty("balance")]
        public List<BalanceItem> Balances { get; set; }
    }

    public class BalanceItem:IBalanceItem
    {
        [JsonProperty("account_id")]
        public string AccountID { get; set; }
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("balance")]
        public double AccountBalance { get; set; }
        [JsonProperty("reserved")]
        public double Reserved { get; set; }
        [JsonProperty("unconfirmed")]
        public double Unconfirmed { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
