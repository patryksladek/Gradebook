﻿namespace Gradebook.Domain.Entities;

public class Department : Entity
{
    public string Name { get; set; }
    public string Building { get; set; }

    public ICollection<Student> Students { get; set; }
}
