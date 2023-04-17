using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Gradebook.Domain.Abstractions;

namespace Gradebook.Infrastructure.Repositories;

internal class CourseRepository : ICourseRepository
{
    private readonly GradebookDbContext _dbContext;

    public CourseRepository(GradebookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Course> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbContext.Courses
        .Include(x => x.CourseStudents)
        .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Course> GetByIdWithStudentsAsync(int id, CancellationToken cancellationToken = default)
         => await _dbContext.Courses
                .Include(x => x.CourseStudents).ThenInclude(x => x.Student)
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);


    public async Task<bool> IsAlreadyExistAsync(string name, CancellationToken cancellationToken = default)
        => await _dbContext.Courses.AnyAsync(x => x.Name == name, cancellationToken);

    public void Add(Course course)
       => _dbContext.Courses.Add(course);

    public void Update(Course course)
        => _dbContext.Courses.Update(course);
}
