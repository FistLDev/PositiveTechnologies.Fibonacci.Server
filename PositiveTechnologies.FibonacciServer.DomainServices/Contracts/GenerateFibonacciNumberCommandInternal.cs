using MediatR;

namespace PositiveTechnologies.FibonacciServer.DomainServices.Contracts;

public sealed record GenerateFibonacciNumberCommandInternal(int FibonacciNumber) : IRequest;