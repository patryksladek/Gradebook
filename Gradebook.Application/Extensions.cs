using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gradebook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(executingAssembly);

        return services;
    }
}
