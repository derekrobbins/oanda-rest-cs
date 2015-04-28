namespace Rabun.Oanda.Rest.Models
{
    public class TransactionStopOrderCreate : TransactionSimple
    {
        public int Expiry { get; set; }
        public OandaTypes.Reason Reason { get; set; }
    }
}