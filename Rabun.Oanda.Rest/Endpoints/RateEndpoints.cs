using System.Collections.Generic;
using System.Threading.Tasks;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Endpoints
{

    public class RateEndpoints : Endpoint
    {
        private static string _instrumentsRoute = "/v1/instruments";
        private static string _priceRoute = "/v1/prices";
        private static string _candleRoute = "/v1/candles";
        private readonly int _accountId;

        public RateEndpoints(string key, AccountType accountType, int accountId)
            : base(key, accountType)
        {
            _accountId = accountId;
        }

        #region GetInstruments

        public async Task<List<InstrumentModel>> GetInstruments()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("accountId", _accountId);

            InstrumentWrapper result = await this.Get<InstrumentWrapper>(null, properties, _instrumentsRoute);
            return result.Instruments;

        }

        public async Task<List<InstrumentModel>> GetInstruments(string fields)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("accountId", _accountId);
            properties.Add("fields", fields);

            InstrumentWrapper result = await this.Get<InstrumentWrapper>(null, properties, _instrumentsRoute);
            return result.Instruments;

        }

        public async Task<List<InstrumentModel>> GetInstruments(string fields, string instruments)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("accountId", _accountId);
            properties.Add("fields", fields);
            properties.Add("instruments", instruments);

            InstrumentWrapper result = await this.Get<InstrumentWrapper>(null, properties, _instrumentsRoute);
            return result.Instruments;

        }

        private class InstrumentWrapper
        {
            public List<InstrumentModel> Instruments { get; set; }
        }

        #endregion

    }
}
