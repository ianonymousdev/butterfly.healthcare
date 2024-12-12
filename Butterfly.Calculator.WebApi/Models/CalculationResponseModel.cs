using System;
using System.ComponentModel.DataAnnotations;

namespace Butterfly.Calculator.Models
{
    public class CalculationResponseModel
    {
        public int Id { get; set; }

        public string Type { get; set; }
        
        public string Expression { get; set; }

        public DateTime CreateDate { get; set; }

        public double Result { get; set; }
    }
}
