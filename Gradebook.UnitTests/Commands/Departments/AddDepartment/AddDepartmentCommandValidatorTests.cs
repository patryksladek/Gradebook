using FluentValidation.TestHelper;
using Gradebook.Application.Commands.Departments.AddDepartment;
using Gradebook.Domain.Abstractions;
using Moq;

namespace Gradebook.UnitTests.Commands.Departments.AddDepartment;

public class AddDepartmentCommandValidatorTests
{
    private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
    
    public AddDepartmentCommandValidatorTests()
    {
        _departmentRepositoryMock = new();
    }

    [Fact]
    public void ValidationResult_Should_Not_HaveAnyValidationErrors_WhenAddDepartmentCommandIsValidated()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Informatyki i Zarządnia",
            Building = "B-4"
        };

        _departmentRepositoryMock.Setup(
           x => x.IsAlreadyExistAsync(
               It.IsAny<string>(),
               It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddDepartmentCommandValidator();

        // Act
        var validationResult = validator.TestValidate(command);

        // Assert
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForName_WhenNameIsEmpty()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = string.Empty,
            Building = "B-4"
        };

        _departmentRepositoryMock.Setup(
          x => x.IsAlreadyExistAsync(
              It.IsAny<string>(),
              It.IsAny<CancellationToken>()))
           .ReturnsAsync(false);

        var validator = new AddDepartmentCommandValidator();

        // Act
        var validationResult = validator.TestValidate(command);

        // Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForName_WhenNameHasMoreThan120Characters()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consectetur nisi diam, vel faucibus purus suscipit id.",
            Building = "B-4"
        };

        _departmentRepositoryMock.Setup(
           x => x.IsAlreadyExistAsync(
               It.IsAny<string>(),
               It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddDepartmentCommandValidator();

        // Act
        var validationResult = validator.TestValidate(command);

        // Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForBuilding_WhenBuildingIsEmpty()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Informatyki i Zarządnia",
            Building = string.Empty
        };

        _departmentRepositoryMock.Setup(
           x => x.IsAlreadyExistAsync(
               It.IsAny<string>(),
               It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddDepartmentCommandValidator();

        // Act
        var validationResult = validator.TestValidate(command);

        // Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Building);
    }

    [Fact]
    public void ValidationResult_Should_HaveValidationErrorForBuilding_WhenNameHasMoreThan8Characters()
    {
        // Arrange
        var command = new AddDepartmentCommand()
        {
            Name = "Wydział Informatyki i Zarządnia",
            Building = "Lorem eu."
        };

        _departmentRepositoryMock.Setup(
           x => x.IsAlreadyExistAsync(
               It.IsAny<string>(),
               It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var validator = new AddDepartmentCommandValidator();

        // Act
        var validationResult = validator.TestValidate(command);

        // Assert
        validationResult.ShouldHaveValidationErrorFor(x => x.Building);
    }
}