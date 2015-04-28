using System;

namespace Rabun.Oanda.Rest.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int accountId { get; set; }
        public string time { get; set; }
        public OandaTypes.TransactionType type { get; set; }
    }
}