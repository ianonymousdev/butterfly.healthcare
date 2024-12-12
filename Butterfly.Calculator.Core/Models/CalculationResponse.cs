using System;

namespace Butterfly.Calculator.Core.Models
{
    public class CalculationResponse
    {
            public int Id { get; set; }

            public string Type { get; set; }
            
            public string Expression { get; set; }

            public DateTime CreateDate { get; set; }

            public double Result { get; set; }
    }
}