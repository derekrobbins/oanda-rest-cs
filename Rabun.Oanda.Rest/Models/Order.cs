using System;

namespace Rabun.Oanda.Rest.Models
{
    public class Order
    {
        public int Id { get; set; }
        public String Instrument { get; set; }
        public String Time { get; set; }
        public float Price { get; set; }
        public OandaTypes.OrderType Type { get; set; }
        public OandaTypes.Side Side { get; set; }
    }
}