using FluentAssertions;
using Gradebook.Application.Commands.Departments.AddDepartment;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Gradebook.IntegrationTests;

public class DepartmentsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private HttpClient _client;
    private WebApplicationFactory<Program> _factory;

    public DepartmentsControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbContextOptions = services
                    .SingleOrDefault(services => services.ServiceType == typeof(DbContextOptions<GradebookDbContext>));

                    services.Remove(dbContextOptions);

                    services.AddDbContext<GradebookDbContext>(options => options.UseInMemoryDatabase("GradebookDb"));
                });
            });
        
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_Should_ReturnListOfDepartmentsAndStatusCodeOK()
    {
        // Arragne
        var scopeFacotry = _factory.Services.GetService<IServiceScopeFactory>();
        using var scope = scopeFacotry.CreateScope();
        var _dbContext = scope.ServiceProvider.GetService<GradebookDbContext>();

        _dbContext.Departments.AddRange(
            new Department() { Name = "Wydział Architektury", Building = "A-1" },
            new Department() { Name = "Wydział Informatki i Zarządzania", Building = "A-2" });
        _dbContext.SaveChanges();

        // Act
        var response = await _client.GetAsync("/api/departments");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<IEnumerable<DepartmentDto>>(content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Post_Should_ReturnNewDepartmentAndStatusCodeCreated()
    {
        // Arragne
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Architektury",
            Building = "A-1"
        };
        var jsonString = JsonConvert.SerializeObject(command);
        var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/departments", stringContent);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<DepartmentDto>(content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Should().NotBeNull();
        result.Should().BeOfType<DepartmentDto>();
        Assert.Equal(result.Name, command.Name);
        Assert.Equal(result.Building, command.Building);
    }

    [Fact]
    public async Task Delete_Should_ReturnStatusCodeNoContent()
    {
        // Arragne
        var scopeFacotry = _factory.Services.GetService<IServiceScopeFactory>();
        using var scope = scopeFacotry.CreateScope();
        var _dbContext = scope.ServiceProvider.GetService<GradebookDbContext>();

        var department = _dbContext.Departments.Add(
            new Department() { Name = "Wydział Architektury", Building = "A-1" });
        _dbContext.SaveChanges();

        int departmentId = department.Entity.Id;

        // Act
        var response = await _client.DeleteAsync($"/api/departments/{departmentId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

}
