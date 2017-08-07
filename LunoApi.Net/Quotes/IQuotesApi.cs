using LunoApi.Net.Quotes.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Quotes
{
    public interface IQuotesApi
    {
        Task<IQuote> CreateQuote(string quoteType, double baseAmount, string currencyPair);
    }
}
