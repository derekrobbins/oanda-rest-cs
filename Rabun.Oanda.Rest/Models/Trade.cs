namespace Rabun.Oanda.Rest.Models
{
    public class Trade
    {
        public int id { get; set; }
        public int units { get; set; }
        public OandaTypes.Side side;
        public string instrument { get; set; }
        public string time { get; set; }
        public float price { get; set; }
        public float takeProfit { get; set; }
        public float stopLoss { get; set; }
        public float trailingStop { get; set; }
        public float trailingAmount { get; set; }
    }
}
