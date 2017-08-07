using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<T> GetPublicData<T>(string command, params object[] parameters)
        {
            return await GetData<T>(command, false, parameters);            
        }

        public async Task<T> GetAuthData<T>(string command, params object[] parameters)
        {
            return await GetData<T>(command, true, parameters);            
        }

        private async Task<T> GetData<T>(string command, bool authenticate, params object[] parameters)
        {
            var relativeUrl = CreateUrlParameters(command, parameters);
            HttpClientHandler handler = new HttpClientHandler();
            var uri = _lunoConfig.PublicAPIUrl + relativeUrl;
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(uri);
                if (authenticate)
                {
                    var byteArray = Encoding.ASCII.GetBytes(String.Format("{0}:{1}", _lunoConfig.ID, _lunoConfig.Secret));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
                var result = await client.GetAsync(uri);
                var resultString = await result.Content.ReadAsStringAsync();
                try
                {
                    var output = Util.JsonSerializer.DeserializeObject<T>(resultString);
                    return output;
                }
                catch (Exception e)
                {
                    throw new LunoException(resultString);
                }
            }

        }
        public async Task<T> PostPublicData<T>(string command, params KeyValuePair<string, object>[] parameters)
        {
            return await PostData<T>(command, false, parameters);
        }

        public async Task<T> PostAuthData<T>(string command, params KeyValuePair<string, object>[] parameters)
        {
            return await PostData<T>(command, true, parameters);
        }

        private async Task<T> PostData<T>(string command, bool authenticate, params KeyValuePair<string, object>[] parameters)
        {            
            HttpClientHandler handler = new HttpClientHandler();
            var uri = _lunoConfig.PublicAPIUrl + command;
            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(uri);
                var content = CreateHttpPostParams(parameters);
                var postBytes = Encoding.ASCII.GetBytes(content);
                var byteArrayContent = new ByteArrayContent(postBytes);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                
                if (authenticate)
                {
                    var byteArray = Encoding.ASCII.GetBytes(String.Format("{0}:{1}", _lunoConfig.ID, _lunoConfig.Secret));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }
               
               
                var result = await client.PostAsync(uri, byteArrayContent);
                var resultString = await result.Content.ReadAsStringAsync();
                try
                {
                    var output = Util.JsonSerializer.DeserializeObject<T>(resultString);
                    return output;
                }
                catch (Exception e)
                {
                    throw new LunoException(resultString);
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

        private static string CreateHttpPostParams(KeyValuePair<string,object>[] postData)
        {
            var output = string.Empty;
            foreach (var entry in postData)
            {
                var valueString = entry.Value as string;
                if (valueString == null)
                {
                    output += "&" + entry.Key + "=" + entry.Value;
                }
                else
                {
                    output += "&" + entry.Key + "=" + valueString.Replace(' ', '+');
                }
            }

            return output.Substring(1);
        }

    }
}
