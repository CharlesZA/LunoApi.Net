using LunoApi.Net.Accounts.ResponseObjects;
using LunoApi.Net.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Accounts
{
    public class Accounts: IAccounts
    {
        private LunoApiClient _lunoAPIClient { get; set; }

        internal Accounts(LunoApiClient webClient)
        {
            _lunoAPIClient = webClient;
        }
        public async Task<Balance> GetBalance()
        {            
            var data = await _lunoAPIClient.GetAuthData<Balance>("balance");
            return data;
        }
    }
}
