

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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


	[HttpGet("{id:guid}", Name = "GetStudentForSchool")]
	public IActionResult GetStudentForSchool(Guid schoolId, Guid id)
	{
		var student = _service.StudentService.GetStudent(schoolId, id, trackChanges: false);
		return Ok(student);
	}

	[HttpPost]
	public IActionResult CreateStudentForSchool(Guid schoolId, [FromBody] StudentForCreationDto student)
	{
		if (student is null)
			return BadRequest("StudentForCreationDto object is null");

		var studentToReturn = _service.StudentService.CreateStudentForSchool(schoolId, student, trackChanges: false);

		return CreatedAtRoute("GetStudentForSchool", new { schoolId, id = studentToReturn.Id },
			studentToReturn);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteStudentForSchool(Guid schoolId, Guid id)
	{
		_service.StudentService.DeleteStudentForSchool(schoolId, id, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdateStudentForSchool(Guid schoolId, Guid id,
		[FromBody] StudentForUpdateDto student)
	{
		if (student is null)
			return BadRequest("StudentForUpdateDto object is null");

		_service.StudentService.UpdateStudentForSchool(schoolId, id, student,
			compTrackChanges: false, empTrackChanges: true);

		return NoContent();
	}


	[HttpPatch("{id:guid}")]
	public IActionResult PartiallyUpdateStudentForSchool(Guid schoolId, Guid id,
		[FromBody] JsonPatchDocument<StudentForUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc object sent from client is null.");

		var result = _service.StudentService.GetStudentForPatch(schoolId, id, compTrackChanges: false,
			empTrackChanges: true);

		patchDoc.ApplyTo(result.studentToPatch);

		_service.StudentService.SaveChangesForPatch(result.studentToPatch, result.studentEntity);

		return NoContent();
	}
}
