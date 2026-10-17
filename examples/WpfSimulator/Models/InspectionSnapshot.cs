using System;

namespace WpfSimulator.Models
{
    public sealed class InspectionSnapshot
    {
        public DateTime Timestamp { get; set; }
        public string Station { get; set; }
        public bool IsOk { get; set; }
        public double SimulatedOffsetMm { get; set; }
    }
}
