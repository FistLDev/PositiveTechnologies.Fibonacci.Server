using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PositiveTechnologies.FibonacciServer.Infrastructure.Configuration;
using PositiveTechnologies.FibonacciServer.Infrastructure.Interfaces;

namespace PositiveTechnologies.FibonacciServer.Infrastructure;

public sealed class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMq"));
        services.AddScoped<IEventBus, RabbitMqEventBus>();
    }
}