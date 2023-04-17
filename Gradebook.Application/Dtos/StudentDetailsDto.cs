namespace Gradebook.Application.Dtos;

public class StudentDetailsDto : StudentDto
{
    public AddressDto Address { get; set; }
    public DepartmentDto Department { get; set; }
}
