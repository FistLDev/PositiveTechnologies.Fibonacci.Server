using MediatR;

using PositiveTechnologies.FibonacciServer.Domain;
using PositiveTechnologies.FibonacciServer.DomainServices.Contracts;
using PositiveTechnologies.FibonacciServer.DomainServices.Services;
using PositiveTechnologies.FibonacciServer.Infrastructure.Interfaces;

namespace PositiveTechnologies.FibonacciServer.DomainServices;

internal sealed class GenerateFibonacciNumberCommandInternalHandler : IRequestHandler<GenerateFibonacciNumberCommandInternal>
{
    private readonly IEventBus _eventBus;

    public GenerateFibonacciNumberCommandInternalHandler(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task Handle(GenerateFibonacciNumberCommandInternal request, CancellationToken cancellationToken)
    {
        var fibonacciNumber = FibonacciNumber.CreateNew(request.FibonacciNumber);
        FibonacciNumber result = FibonacciNumberService.GetNextFibonacci(fibonacciNumber);

        await _eventBus.SendMessage(result.Value, cancellationToken);
    }
}