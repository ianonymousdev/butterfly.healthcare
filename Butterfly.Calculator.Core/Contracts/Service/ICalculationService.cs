using Butterfly.Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Calculator.Core.Contracts.Service
{
    public interface ICalculationService
    {
        Task<double[]> Calculate(CalculationRequest request);
    }
}
