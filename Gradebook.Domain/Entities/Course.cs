﻿namespace Gradebook.Domain.Entities;

public class Course : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<StudentCourse> CourseStudents { get; set; }
}

