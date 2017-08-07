using LunoApi.Net.Common;
using LunoApi.Net.Quotes.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Quotes
{
    class QuotesApi: IQuotesApi
    {
        private LunoApiClient _lunoAPIClient { get; set; }

        internal QuotesApi(LunoApiClient webClient)
        {
            _lunoAPIClient = webClient;
        }
        public async Task<IQuote> CreateQuote(string quoteType, double baseAmount, string currencyPair)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("type", quoteType));
            parameters.Add(new KeyValuePair<string, object>("base_amount", baseAmount.ToString()));
            parameters.Add(new KeyValuePair<string, object>("pair", currencyPair));
            var data = await _lunoAPIClient.PostAuthData<Quote>("quotes", parameters.ToArray());
            return data;
        }

    }
}
