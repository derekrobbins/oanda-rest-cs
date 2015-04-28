namespace Rabun.Oanda.Rest.Models
{
    public class TransactionTradeClose : TransactionSimple
    {
        public float Pl { get; set; }
        public int Interest { get; set; }
        public float AccountBalance { get; set; }
        public int TradeId { get; set; }
    }
}