namespace Rabun.Oanda.Rest.Models
{
    public class TransactionTradeUpdate : Transaction
    {
        public int Units { get; set; }
        public OandaTypes.Side Side { get; set; }
        public float StopLossPrice { get; set; }
        public int TradeId { get; set; }

    }
}