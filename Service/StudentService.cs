
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class StudentService : IStudentService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;


	public StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;

	}

	public IEnumerable<StudentDto> GetStudents(Guid schoolId, bool trackChanges)
	{
		var school = _repository.School.GetSchool(schoolId, trackChanges);
        if (school is null)
            throw new SchoolNotFoundException(schoolId);

        var studentsFromDb = _repository.Student.GetStudents(schoolId, trackChanges);
		var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);

		return studentsDto;
	}

	public StudentDto GetStudent(Guid schoolId, Guid id, bool trackChanges)
	{
		var school = _repository.School.GetSchool(schoolId, trackChanges);
		if (school is null)
			throw new SchoolNotFoundException(schoolId);

		var studentDb = _repository.Student.GetStudent(schoolId, id, trackChanges);
		if (studentDb is null)
			throw new StudentNotFoundException(id);

		var student = _mapper.Map<StudentDto>(studentDb);
		return student;
	}

	public StudentDto CreateStudentForSchool(Guid schoolId, StudentForCreationDto studentForCreation, bool trackChanges)
	{
		var school = _repository.School.GetSchool(schoolId, trackChanges);
		if (school is null)
			throw new StudentNotFoundException(schoolId);

		var studentEntity = _mapper.Map<Student>(studentForCreation);

		_repository.Student.CreateStudentForSchool(schoolId, studentEntity);
		_repository.Save();

		return _mapper.Map<StudentDto>(studentEntity);
	}
}
