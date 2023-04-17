using AutoMapper;
using FluentValidation.TestHelper;
using Gradebook.Application.Commands.Departments.AddDepartment;
using Gradebook.Application.Configuration.Mappings;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions.Department;
using Moq;

namespace Gradebook.UnitTests.Commands.Departments.AddDepartment;

public class AddDepartmentCommandHandlerTests
{
    private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IMapper _mapper;

    public AddDepartmentCommandHandlerTests()
    {
        _departmentRepositoryMock = new();
        _unitOfWork = new();
        _mapper = MapperHelper.CreateMapper(new DepartmentMappingProfile());
    }

    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenNameIsUnique()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Informatyki i Zarządnia",
            Building = "A-2"
        };

        _departmentRepositoryMock.Setup(
            x => x.Add(It.IsAny<Department>()));

        var handler = new AddDepartmentCommandHandler(
            _departmentRepositoryMock.Object,
            _unitOfWork.Object,
            _mapper);

        // Act
        var departmentDto = await handler.Handle(command, default);

        // Assert
        _departmentRepositoryMock.Verify(
            x => x.Add(It.Is<Department>(s => s.Id == departmentDto.Id)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowDepartmentNameIsNotUniqueException_WhenNameIsNotUnique()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Informatyki i Zarządnia",
            Building = "A-2"
        };

        _departmentRepositoryMock.Setup(
           x => x.IsAlreadyExistAsync(
               It.IsAny<string>(),
               It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _departmentRepositoryMock.Setup(
            x => x.Add(It.IsAny<Department>()));

        var handler = new AddDepartmentCommandHandler(
           _departmentRepositoryMock.Object,
           _unitOfWork.Object,
           _mapper);

        // Act & Assert
        await Assert.ThrowsAsync<DepartmentAlreadyExistsException>(async() => await handler.Handle(command, default));
    }
}
