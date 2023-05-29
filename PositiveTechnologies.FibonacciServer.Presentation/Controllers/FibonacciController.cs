using MediatR;

using Microsoft.AspNetCore.Mvc;

using PositiveTechnologies.FibonacciServer.DomainServices.Contracts;

namespace PositiveTechnologies.FibonacciServer.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly IMediator _mediator;

    public FibonacciController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate/{fibonacciNumber}")]
    public async Task Generate(int fibonacciNumber, CancellationToken cancellationToken)
    {
        var commandInternal = new GenerateFibonacciNumberCommandInternal(fibonacciNumber);

        await _mediator.Send(commandInternal, cancellationToken);
    }
}