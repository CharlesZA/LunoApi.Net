using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Accounts.ResponseObjects
{
    public interface IBalanceItem
    {
        string AccountID { get; }
        string Asset { get; }
        double AccountBalance { get; }
        double Reserved { get; }
        double Unconfirmed { get; }
        string Name { get; }
    }
}
