namespace Rabun.Oanda.Rest.Models
{
    class TradeClosed
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Instrument { get; set; }
        public float Profit { get; set; }
        public OandaTypes.Side Side { get; set; }
        public string Time { get; set; }
    }
}
