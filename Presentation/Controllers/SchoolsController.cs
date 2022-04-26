using API.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers;

[Route("api/schools")]
[ApiController]
public class SchoolsController : ControllerBase
{
	private readonly IServiceManager _service;

	public SchoolsController(IServiceManager service) => _service = service;

	[HttpGet]
	public IActionResult GetSchools()
	{
		//throw new Exception("Exception");
		var schools = _service.SchoolService.GetAllSchools(trackChanges: false);

			return Ok(schools);
	}


	[HttpGet("{id:guid}", Name = "SchoolById")]
	public IActionResult GetSchool(Guid id)
	{
		var school = _service.SchoolService.GetSchool(id, trackChanges: false);
		return Ok(school);
	}

	[HttpGet("collection/({ids})", Name = "SchoolCollection")]
	public IActionResult GetSchoolCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
	//public IActionResult GetSchoolCollection(IEnumerable<Guid> ids)
	{
		var schools = _service.SchoolService.GetByIds(ids, trackChanges: false);

		return Ok(schools);
	}

	[HttpPost]
	public IActionResult CreateSchool([FromBody] SchoolForCreationDto school)
	{
		if (school is null)
			return BadRequest("SchoolForCreationDto object is null");

		var createdSchool = _service.SchoolService.CreateSchool(school);

		return CreatedAtRoute("SchoolById", new { id = createdSchool.Id }, createdSchool);
	}


	[HttpPost("collection")]
	public IActionResult CreateSchoolCollection([FromBody] IEnumerable<SchoolForCreationDto> schoolCollection)
	{
		var result = _service.SchoolService.CreateSchoolCollection(schoolCollection);

		return CreatedAtRoute("SchoolCollection", new { result.ids }, result.schools);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteCompany(Guid id)
	{
		_service.SchoolService.DeleteSchool(id, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdateSchool(Guid id, [FromBody] SchoolForUpdateDto school)
	{
		if (school is null)
			return BadRequest("SchoolForUpdateDto object is null");

		_service.SchoolService.UpdateSchool(id, school, trackChanges: true);

		return NoContent();
	}
}