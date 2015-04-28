using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using unirest_net.request;

namespace Rabun.Oanda.Rest.Base
{
    public abstract class Endpoint
    {
        private string _key;
        private AccountType _accountType;
        protected static string realEndpoint = "https://api-fxtrade.oanda.com";
        protected static string practiceEndpoint = "https://api-fxpractice.oanda.com";

        protected Endpoint(string key, AccountType accountType)
        {
            this._key = key;
            this._accountType = accountType;
        }

        protected String makeEndpoint(AccountType accountType, String route)
        {

            if (accountType == AccountType.practice)
                return string.Format("{0}{1}", practiceEndpoint, route);

            if (accountType == AccountType.real)
                return string.Format("{0}{1}", realEndpoint, route);

           return null;
        }

        private void SetRouteParams(string endpoint, Dictionary<string, string> routeParams)
        {

            Regex rx = new Regex("[:](\\S[^/]*)");
            MatchCollection matches = rx.Matches(endpoint);

            foreach (Match match in matches)
            {
                foreach (KeyValuePair<string, string> routeParam in routeParams)
                {
                    if (match.Value == routeParam.Key)
                    {
                        match.Result(routeParam.Value);
                    }
                }
            }
        }


        public Task<HttpResponseMessage> Get<T>(KeyValuePair<string, object> routeParams, Dictionary<string, object> fields, string endpoint)
        {
        }

    }
}
