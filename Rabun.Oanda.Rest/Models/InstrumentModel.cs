using System;

namespace Rabun.Oanda.Rest.Models
{
    public class InstrumentModel
    {
        public String Instrument { get; set; }
        public String DisplayName { get; set; }
        public float Pip { get; set; }
        public int PaxTradeUnits { get; set; }
    }
}