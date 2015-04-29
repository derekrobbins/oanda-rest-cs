using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rabun.Oanda.Rest.Base
{
    public abstract class Endpoint
    {
        private string _key;
        private AccountType _accountType;
        private static string realEndpoint = "https://api-fxtrade.oanda.com";
        private static string practiceEndpoint = "https://api-fxpractice.oanda.com";

        protected Endpoint(string key, AccountType accountType)
        {
            _key = key;
            _accountType = accountType;
        }

        private string MakeEndpoint(AccountType accountType, string route)
        {

            if (accountType == AccountType.practice)
                return string.Format("{0}{1}", practiceEndpoint, route);

            if (accountType == AccountType.real)
                return string.Format("{0}{1}", realEndpoint, route);

            return null;
        }

        private string MakeUrl(string endpoint, Dictionary<string, string> routeParams)
        {
            if (routeParams != null)
            {
                Regex rx = new Regex("[:](\\S[^/]*)");
                MatchCollection matches = rx.Matches(endpoint);

                foreach (Match match in matches)
                {
                    foreach (KeyValuePair<string, string> routeParam in routeParams)
                    {
                        if (match.Groups[1].Value == routeParam.Key)
                        {
                            endpoint = endpoint.Replace(match.Value, routeParam.Value);
                        }
                    }
                }
            }

            return endpoint;
        }


        protected async Task<T> Get<T>(Dictionary<string, string> routeParams, Dictionary<string, object> properties, string route)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = MakeUrl(MakeEndpoint(_accountType, route), routeParams);

                StringBuilder sb = new StringBuilder(url);
                sb.Append("?");
                foreach (var p in properties)
                {
                    sb.AppendFormat("{0}={1}&", p.Key, p.Value);
                }
                sb.Remove(sb.Length - 1, 1);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, sb.ToString()))
                {

                    request.Headers.Add("Authorization", string.Format("Bearer {0}", _key));

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string str = await response.Content.ReadAsStringAsync();
                        T result = JsonConvert.DeserializeObject<T>(str);
                        return result;
                    }
                    else
                    {
                        if (response.Content != null)
                        {
                            string str = await response.Content.ReadAsStringAsync();
                            throw new Exception(str);
                        }
                        else
                        {
                            throw new Exception(response.StatusCode.ToString());
                        }
                    }

                }
            }
        }

    }
}
