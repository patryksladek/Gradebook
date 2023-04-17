namespace Gradebook.Domain.Entities;

public class Grade : Entity
{
    public GradeType Type { get; set; }
    public double Value { get; set; }

    public int StudentCourseId { get; set; }
    public StudentCourse StudentCourse { get; set; }
}
