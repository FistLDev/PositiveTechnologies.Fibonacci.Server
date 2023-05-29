using EasyNetQ;

using IEventBus = PositiveTechnologies.FibonacciServer.Infrastructure.Interfaces.IEventBus;

namespace PositiveTechnologies.FibonacciServer.Infrastructure;

internal sealed class RabbitMqEventBus : IEventBus
{
    private readonly IBus _bus;

    public RabbitMqEventBus(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendMessage(int result, CancellationToken cancellationToken)
    {
        await _bus.PubSub.PublishAsync(result, cancellationToken);
    }
}