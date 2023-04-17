namespace Gradebook.Domain.Entities;

public static class GradeValue
{
    public const double Unsatisfactory = 2.0;
    public const double Satisfactory = 3.0;
    public const double SatisfactoryPlus = 3.5;
    public const double Good = 4.0;
    public const double GoodPlus = 4.5;
    public const double VeryGood = 5.0;
    public const double Excellent = 5.5;

    public static bool IsValid(double grade)
    {
        return grade == Unsatisfactory || grade == Satisfactory || grade == SatisfactoryPlus ||
               grade == Good || grade == GoodPlus || grade == VeryGood || grade == Excellent;
    }
}
