using Gradebook.Domain.Abstractions;
using Gradebook.Infrastructure.Context;
using Gradebook.Infrastructure.Options;
using Gradebook.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Gradebook.Infrastructure;

public static class Extensions
{
    private const string SectionName = "MsSqlConnection";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IStudentReadOnlyRepository, StudentReadOnlyRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<IDepartmentReadOnlyRepository, DepartmentReadOnlyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<ICourseRepository, CourseRepository>();

        var options = configuration.GetOptions<MsSqlOptions>(SectionName);
        services.AddDbContext<GradebookDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

        return services;
    }

    public static ConfigureHostBuilder UseInfrastructure(this ConfigureHostBuilder host)
    {
        host.UseNLog();

        return host;
    }
}
