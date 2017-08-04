using LunoApi.Net.Accounts.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Accounts
{
    public interface IAccounts
    {
        Task<Balance> GetBalance();
    }
}
