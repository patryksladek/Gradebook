using Gradebook.Application.Dtos;
using Gradebook.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Gradebook.Application.Queries.Grades.GetGradeValues;

internal class GetGradeValuesQueryHandler : IRequestHandler<GetGradeValuesQuery, IEnumerable<double>>
{
    public async Task<IEnumerable<double>> Handle(GetGradeValuesQuery request, CancellationToken cancellationToken)
    {
        IList<double> gradeTypesDto = new List<double>
        {
            GradeValue.Unsatisfactory,
            GradeValue.Satisfactory,
            GradeValue.SatisfactoryPlus,
            GradeValue.Good,
            GradeValue.GoodPlus,
            GradeValue.VeryGood,
            GradeValue.Excellent
        };

        await Task.CompletedTask;

        return gradeTypesDto;
    }
}
