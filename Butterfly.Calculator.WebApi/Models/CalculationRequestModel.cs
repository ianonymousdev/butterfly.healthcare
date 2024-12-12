using System;
using System.ComponentModel.DataAnnotations;

namespace Butterfly.Calculator.Models
{
    public class CalculationRequestModel
    {
        [Required]
        public double Addend1 { get; set; }
        [Required]
        public double Addend2 { get; set; }
        [Required]
        public string Operation { get; set; }
    }
}
