using Butterfly.Calculator.Core.Contracts.Service;
using Butterfly.Calculator.Core.Models;
using Butterfly.Calculator.Public.Enums;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Butterfly.Calculator.Common.Contants;
using System;


namespace Butterfly.Calculator.Services
{
    public class CalculationService : ICalculationService
    {
        public async Task<double[]> Calculate(CalculationRequest request) 
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Calculation request cannot be null.");

            if (request.Operation == Operation.Divide && request.Addend2 == 0)
                throw new InvalidOperationException("Division by zero is not allowed.");

            double result = request.Operation switch
            {
                Operation.Add => request.Addend1 + request.Addend2,
                Operation.Subtract => request.Addend1 - request.Addend2,
                Operation.Multiply => request.Addend1 * request.Addend2,
                Operation.Divide => request.Addend1 / request.Addend2,
                _ => throw new ArgumentException("Invalid operation", nameof(request.Operation))
            };

            // Return the result as a single-element array for flexibility in case you want to return multiple results in the future.
            return await Task.FromResult(new[] { result });
        }
    }
}

