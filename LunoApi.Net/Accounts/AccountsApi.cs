using LunoApi.Net.Accounts.ResponseObjects;
using LunoApi.Net.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Accounts
{
    public class AccountsApi: IAccountsApi
    {
        private LunoApiClient _lunoAPIClient { get; set; }

        internal AccountsApi(LunoApiClient webClient)
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
