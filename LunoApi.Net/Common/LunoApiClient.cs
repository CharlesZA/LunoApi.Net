using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LunoApi.Net.Common
{
    sealed class LunoApiClient
    {
        private IConfig _lunoConfig;

        public LunoApiClient(IConfig lunoConfig)
        {
            _lunoConfig = lunoConfig;
        }

        public async Task<T> GetUnAuthenticatedData<T>(string command, params object[] parameters)
        {
            var relativeUrl = CreateUrlParameters(command, parameters);
            HttpClientHandler handler = new HttpClientHandler();
            var uri = _lunoConfig.PublicAPI + relativeUrl;
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(uri);
                var result = await client.GetAsync(uri);
                var resultString = await result.Content.ReadAsStringAsync();
                try
                {
                    var output = Util.JsonSerializer.DeserializeObject<T>(resultString);
                    return output;
                }
                catch (Exception e)
                {
                    var error = Util.JsonSerializer.DeserializeObject<LunoError>(resultString);
                    throw new LunoException(error.error);
                }               
            }
        }

        private static string CreateUrlParameters(string command, object[] parameters)
        {
            var baseCommand = command;
            if (parameters.Length != 0)
            {
                baseCommand += "?" + string.Join("&", parameters);
            }

            return baseCommand;
        }
    }
}
