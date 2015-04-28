using System;

namespace Rabun.Oanda.Rest.Models
{
    public class Position
    {
        public String Instrument { get; set; }
        public int Units { get; set; }
        public OandaTypes.Side Side { get; set; }
        public float AvgPrice { get; set; } 
    }
}