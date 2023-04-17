﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Gradebook.Application.Configuration.Commands;
using Gradebook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions.Student;

namespace Gradebook.Application.Commands.Students.AddStudent;

internal class AddStudentCommandHandler : ICommandHandler<AddStudentCommand, StudentDetailsDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private IValidator<AddStudentCommand> _validator;

    public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddStudentCommand> validator)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<StudentDetailsDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
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
            YearEnrolled = request.YearEnrolled,
            Address = new Address()
            {
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country
            }
        };
            
        _studentRepository.Add(newStudent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var studentDto = _mapper.Map<StudentDetailsDto>(newStudent);

        return studentDto;
    }
}
