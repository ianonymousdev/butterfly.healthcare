using Butterfly.Calculator.Public.Enums;

namespace Butterfly.Calculator.Core.Models
{
    public class CalculationRequest
    {
        public double Addend1 { get; set; }
        public double Addend2 { get; set; }
        public Operation Operation { get; set; }
    }
}
