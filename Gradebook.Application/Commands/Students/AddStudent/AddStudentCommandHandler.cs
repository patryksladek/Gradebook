﻿using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions.Student;
using MediatR;

namespace Gradebook.Application.Commands.Students.AddStudent;

internal class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _studentRepository.IsAlreadyExistAsync(request.Email, cancellationToken);
        if (isAlreadyExist)
        {
            throw new StudentAlreadyExistsException(request.Email);
        }
       
        var newStudent = new Student()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            YearEnrolled = request.YearEnrolled
        };
            
        _studentRepository.Add(newStudent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var studentDto = new StudentDto()
        {
            Id = newStudent.Id,
            FirstName = newStudent.FirstName,
            LastName = newStudent.LastName,
            Email = newStudent.Email,
            Age = DateTime.Today.Year - newStudent.DateOfBirth.ToDateTime(TimeOnly.Parse("10:00")).Year,
            YearEnrolled = newStudent.YearEnrolled
        };

        return studentDto;
    }
}
