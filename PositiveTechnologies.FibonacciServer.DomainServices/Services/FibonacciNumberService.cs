using System.Runtime.CompilerServices;

using PositiveTechnologies.FibonacciServer.Domain;

[assembly: InternalsVisibleTo("PositiveTechnologies.Fibonacci.Server.UnitTests")]

namespace PositiveTechnologies.FibonacciServer.DomainServices.Services;

internal static class FibonacciNumberService
{
    public static FibonacciNumber GetNextFibonacci(FibonacciNumber currentFibonacci)
    {
        if (!IsFibonacciNumber(currentFibonacci))
        {
            throw new ArgumentException("The input number is not a Fibonacci number.");
        }

        var previousFibonacci = 0;
        var nextFibonacci = 1;

        for (var i = 0; i < currentFibonacci.Value; i++)
        {
            int temp = nextFibonacci;
            nextFibonacci = previousFibonacci + nextFibonacci;
            previousFibonacci = temp;
        }

        return FibonacciNumber.CreateNew(nextFibonacci);
    }

    private static bool IsFibonacciNumber(FibonacciNumber number)
    {
        var a = 0;
        var b = 1;

        while (b < number.Value)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }

        return b == number.Value;
    }
}