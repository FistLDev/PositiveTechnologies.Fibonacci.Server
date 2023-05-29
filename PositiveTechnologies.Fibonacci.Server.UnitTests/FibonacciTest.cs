using PositiveTechnologies.FibonacciServer.Domain;
using PositiveTechnologies.FibonacciServer.DomainServices.Services;

namespace PositiveTechnologies.Fibonacci.Server.UnitTests;

public class FibonacciTest
{
    [Fact]
    public void CreateFibonacciNumber_Success()
    {
        var fibonacciNumber = 1;

        var result = FibonacciNumber.CreateNew(fibonacciNumber);

        Assert.Equal(fibonacciNumber, result.Value);
    }

    [Fact]
    public void CreateFibonacciNumber_Failed()
    {
        int fibonacciNumber = -3;

        Assert.Throws<ArgumentException>(() => FibonacciNumber.CreateNew(fibonacciNumber));
    }

    [Fact]
    public void GenerateFibonacci_Success()
    {
        var fibonacciNumber = FibonacciNumber.CreateNew(5);
        var expectedResult = 8;

        FibonacciNumber result = FibonacciNumberService.GetNextFibonacci(fibonacciNumber);

        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public void GenerateFibonacci_Failed()
    {
        var fibonacciNumber = FibonacciNumber.CreateNew(4);

        Assert.Throws<ArgumentException>(() => FibonacciNumberService.GetNextFibonacci(fibonacciNumber));
    }
}