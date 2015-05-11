using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Endpoints
{
    public class TransactionEndpoints : Endpoint
    {
        private readonly string _transactionsRoute = "/v1/accounts/:accountId/transactions";
        private readonly int _accountId;

        public TransactionEndpoints(string key, AccountType accountType, int accountId)
            : base(key, accountType)
        {
            _accountId = accountId;
        }

        public async Task<List<Transaction>> GetTransactions(int? maxId, int? minId, int? count, string instrument, string ids)
        {
            Dictionary<string, string> routeParams = new Dictionary<string, string>();
            routeParams.Add("accountId", _accountId.ToString());

            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(instrument)) properties.Add("instrument", instrument);
            if (count != null) properties.Add("count", count);
            if (maxId != null) properties.Add("maxId", maxId);
            if (minId != null) properties.Add("minId", minId);
            if (!string.IsNullOrWhiteSpace(ids)) properties.Add("ids", ids);

            dynamic result = Get<dynamic>(routeParams, properties, _transactionsRoute);

            OandaTypes.TransactionType type;
            Enum.TryParse(result.transactions[0].type, out type);

            List<Transaction> transactions = new List<Transaction>();
            switch (type)
            {
                case OandaTypes.TransactionType.MARKET_ORDER_CREATE:
                    {
                        string j = JsonConvert.SerializeObject(result);
                        List<TransactionMarketOrderCreate> transactionMarketOrderCreates =
                            JsonConvert.DeserializeObject<List<TransactionMarketOrderCreate>>(j);

                        transactions = fillTransactions(transactionMarketOrderCreates);

                        break;
                    }
                case OandaTypes.TransactionType.LIMIT_ORDER_CREATE:
                    {
                        break;
                    }
            }

            return transactions;

        }

        private List<Transaction> fillTransactions<T>(List<T> trs) where T: Transaction
        {
            return trs.Cast<Transaction>().ToList();
        }
    }
}
