using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Endpoints
{
    public class RateEndpoints: Endpoint
    {
        public RateEndpoints(string key, AccountType accountType) : base(key, accountType)
        {
        }

        public async Task<List<InstrumentModel>> GetInstruments()
        {
            Task<HttpResponseMessage> a = this.Get<InstrumentModel>(new KeyValuePair<string, object>("ttt", 1),
                new KeyValuePair<string, object>("mmm", 1), "");

            string b = a.Result.Content.ReadAsStringAsync().Result;
            List<InstrumentModel> instruments = JsonConvert.DeserializeObject<List<InstrumentModel>>(b);

            return instruments;
        }
    }
}
