namespace PositiveTechnologies.FibonacciServer.Infrastructure.Interfaces;

public interface IEventBus
{
    Task SendMessage(int result, CancellationToken cancellationToken);
}