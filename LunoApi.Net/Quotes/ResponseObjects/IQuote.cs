using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Quotes.ResponseObjects
{
    public interface IQuote
    {
        int QuoteID { get; set; }
        string Type { get; set; }
        string CurrencyPair { get; set; }
        double BaseAmount { get; set; }
        double CounterAmount { get; set; }
        long CreatedAt { get; set; }
        long ExpiresAt { get; set; }
        bool Discarded { get; set; }
        bool Exercised { get; set; }
    }
}
