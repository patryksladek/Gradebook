using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.Domain.Entities;

public enum GradeType
{
    [Display(Name = "Lecture")]
    Lecture,

    [Display(Name = "Classes")]
    Classes,

    [Display(Name = "Laboratory")]
    Laboratory,

    [Display(Name = "Project")]
    Project,

    [Display(Name = "Seminar")]
    Seminar,

    [Display(Name = "Exam")]
    Exam
}