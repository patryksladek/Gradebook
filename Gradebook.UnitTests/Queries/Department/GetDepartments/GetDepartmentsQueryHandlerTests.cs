using AutoMapper;
using Gradebook.Application.Configuration.Mappings;
using Gradebook.Application.Queries.Departments.GetDepartments;
using Gradebook.Domain.Abstractions;
using Moq;

namespace Gradebook.UnitTests.Queries.Department.GetDepartments;

public class GetDepartmentsQueryHandlerTests
{
    private readonly Mock<IDepartmentReadOnlyRepository> _departmentReadOnlyRepositoryMock;
    private readonly IMapper _mapper;

    public GetDepartmentsQueryHandlerTests()
    {
        _departmentReadOnlyRepositoryMock = new();
        _mapper = MapperHelper.CreateMapper(new DepartmentMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallGetAllOnRepository_WhenGetDepartmentsQuery()
    {
        // Arrange
        _departmentReadOnlyRepositoryMock.Setup(
           x => x.GetAllAsync(
               It.IsAny<CancellationToken>()));

        var handler = new GetDepartmentsQueryHandler(
            _departmentReadOnlyRepositoryMock.Object,
            _mapper);

        // Act
        var departmentsDto = await handler.Handle(new GetDepartmentsQuery(), default);

        // Assert
        _departmentReadOnlyRepositoryMock.Verify(
            x => x.GetAllAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
