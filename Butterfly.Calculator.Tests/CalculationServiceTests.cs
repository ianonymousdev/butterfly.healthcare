using Butterfly.Calculator.Core.Models;
using Butterfly.Calculator.Services;
using System.Linq;
using Butterfly.Calculator.Public.Enums;
using System.Threading.Tasks;
using System;
using Xunit;

public class CalculationServiceTests
{
    private readonly CalculationService _calculationService;

    public CalculationServiceTests()
    {
        _calculationService = new CalculationService();
    }

    [Theory]
    [InlineData(10, 5, Operation.Add, 15)]
    [InlineData(10, 5, Operation.Subtract, 5)]
    [InlineData(10, 5, Operation.Multiply, 50)]
    [InlineData(10, 5, Operation.Divide, 2)]
    public async Task Calculate_ValidOperations_ReturnsExpectedResult(double addend1, double addend2, Operation operation, double expected)
    {
        // Arrange
        var request = new CalculationRequest
        {
            Addend1 = addend1,
            Addend2 = addend2,
            Operation = operation
        };

        // Act
        var result = await _calculationService.Calculate(request);

        // Assert
        Assert.Single(result);
        Assert.Equal(expected, result[0]);
    }

    [Fact]
    public async Task Calculate_DivisionByZero_ThrowsInvalidOperationException()
    {
        // Arrange
        var request = new CalculationRequest
        {
            Addend1 = 10,
            Addend2 = 0,
            Operation = Operation.Divide
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _calculationService.Calculate(request));
        Assert.Equal("Division by zero is not allowed.", exception.Message);
    }

    [Fact]
    public async Task Calculate_NullRequest_ThrowsArgumentNullException()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _calculationService.Calculate(null));
        Assert.Equal("Calculation request cannot be null. (Parameter 'request')", exception.Message);
    }

    [Fact]
    public async Task Calculate_InvalidOperation_ThrowsArgumentException()
    {
        // Arrange
        var request = new CalculationRequest
        {
            Addend1 = 10,
            Addend2 = 5,
            Operation = (Operation)999 // Invalid operation
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _calculationService.Calculate(request));
        Assert.Contains("Invalid operation", exception.Message);
    }
}