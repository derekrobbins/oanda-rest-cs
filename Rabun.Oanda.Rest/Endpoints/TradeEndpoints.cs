using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rabun.Oanda.Rest.Base;

namespace Rabun.Oanda.Rest.Endpoints
{
    public class TradeEndpoints: Endpoint
    {
        public TradeEndpoints(string key, AccountType accountType) : base(key, accountType)
        {
        }
    }
}
