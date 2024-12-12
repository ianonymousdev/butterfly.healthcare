using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Butterfly.Calculator.Core;
using Butterfly.Calculator.Core.Models;
using Butterfly.Calculator.Core.Contracts.Service;
using Butterfly.Calculator.Models;
using System.Text.Json;

namespace Butterfly.Calculator.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ILogger<CalculationController> _logger;
        private readonly ICalculationService _calculationService;
        private readonly IMapper _mapper;

        public CalculationController(ILogger<CalculationController> logger, IMapper mapper, ICalculationService calculationService)
        {
            _logger = logger;
            _mapper = mapper;
            _calculationService = calculationService;
        }

        /// <summary>
        /// Performs calculations on two numbers
        /// </summary>
        /// <returns>Result of the calculation</returns>
        [HttpGet("calculate")] // Hit the api endpoint by visiting https://localhost:5001/calculation/calculate?addend1=10&addend2=5&operation=add
        public async Task<ActionResult<CalculationResponseModel>> Calculate(double addend1, double addend2, string operation)
        {
            _logger.LogInformation("Executing Calculate method with addend1: {Addend1}, addend2: {Addend2}, operation: {Operation}", addend1, addend2, operation);
            
            // Validate parameters
            var validationError = ValidateParameters(addend1, addend2, operation);
            if (validationError != null)
            {
                _logger.LogWarning("Validation failed in {MethodName}. Parameters: addend1={Addend1}, addend2={Addend2}, operation={Operation}. Error: {ValidationError}", nameof(Calculate), addend1, addend2, operation, validationError);
                return BadRequest(new { error = validationError });
            }
            
            try
            {
                var calculationRequestModel = new CalculationRequestModel
                {
                    Addend1 = addend1,
                    Addend2 = addend2,
                    Operation = operation
                };
                var calculationRequest = _mapper.Map<CalculationRequest>(calculationRequestModel);
                var calculationResult = await _calculationService.Calculate(calculationRequest);
                
                _logger.LogInformation("Successfully executed {MethodName}. Returning result: {@Result}", nameof(Calculate), calculationResult);
                return Ok(calculationResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred in {MethodName}. Error: {ErrorMessage}", nameof(Calculate), ex.Message);
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
    /// Validates the parameters for the Calculate method.
    /// </summary>
    /// <param name="addend1">The first number</param>
    /// <param name="addend2">The second number</param>
    /// <param name="operation">The operation to perform</param>
    /// <returns>Error message if validation fails, otherwise null</returns>
    private string ValidateParameters(double addend1, double addend2, string operation)
    {
        _logger.LogInformation("Executing ValidateParameters method with addend1: {Addend1}, addend2: {Addend2}, operation: {Operation}", addend1, addend2, operation);

        if (double.IsNaN(addend1))
        {
            return "Invalid parameter: 'addend1' must be a valid number.";
        }

        if (double.IsNaN(addend2))
        {
            return "Invalid parameter: 'addend2' must be a valid number.";
        }

        var allowedOperations = new List<string> { "add", "subtract", "multiply", "divide" };
        if (!allowedOperations.Contains(operation.ToLower()))
        {
            return $"Invalid parameter: 'operation' must be one of {string.Join(", ", allowedOperations)}.";
        }

        if (operation.ToLower() == "divide" && addend2 == 0)
        {
            return "Division by zero is not allowed.";
        }

        return null;
    }
    }
}
