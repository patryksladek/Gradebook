﻿using FluentValidation;
using Gradebook.Application.Commands.Students.AddStudent;
using Gradebook.Application.Commands.Students.UpdateStudent;
using Gradebook.Application.Configuration.Validation;
using Gradebook.Application.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gradebook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(executingAssembly));
        services.AddAutoMapper(executingAssembly);

        services.AddValidatorsFromAssembly(executingAssembly);
        services.AddScoped<IValidator<AddStudentCommand>, AddStudentCommandValidator>();
        services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseApplication(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
