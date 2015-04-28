using System.Collections.Generic;

namespace Rabun.Oanda.Rest.Models
{
    public class Candle<T>
    {
        public string Instrument { get; set; }
        public OandaTypes.GranularityType Granularity { get; set; }
        public List<T> Candles { get; set; }
    }
}
