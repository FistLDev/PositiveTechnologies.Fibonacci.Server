namespace PositiveTechnologies.FibonacciServer.Domain;

public sealed class FibonacciNumber
{
    public readonly int Value;

    private FibonacciNumber(int value)
    {
        Value = value;
    }

    public static FibonacciNumber CreateNew(int fibonacciNumber)
    {
        if (fibonacciNumber < 1)
        {
            throw new ArgumentException($"Unsupported Fibonacci number {fibonacciNumber}");
        }

        return new FibonacciNumber(fibonacciNumber);
    }
}