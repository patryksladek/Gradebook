using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Gradebook.Infrastructure.Options;
using Gradebook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gradebook.Infrastructure;

public static class Extensions
{
    private const string SectionName = "MsSqlConnection";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<MsSqlOptions>(SectionName);
        services.AddDbContext<GradebookDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

        return services;
    }
}
