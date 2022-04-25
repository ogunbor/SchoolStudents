

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers;
[Route("api/schools/{schoolId}/students")]
[ApiController] 
public class StudentsController : ControllerBase 
{
    private readonly IServiceManager _service;
    public StudentsController(IServiceManager service) => _service = service;

	[HttpGet]
	public IActionResult GetStudentsForSchool(Guid schoolId)
	{
		var students = _service.StudentService.GetStudents(schoolId, trackChanges: false);
		return Ok(students);
	}


	[HttpGet("{id:guid}")]
	public IActionResult GetStudentForSchool(Guid schoolId, Guid id)
	{
		var student = _service.StudentService.GetStudent(schoolId, id, trackChanges: false);
		return Ok(student);
	}
}
