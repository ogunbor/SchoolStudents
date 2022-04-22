using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
		try
		{
			var schools = _service.SchoolService.GetAllSchools(trackChanges: false);

			return Ok(schools);
		}
		catch
		{
			return StatusCode(500, "Internal server error");
		}
	}
}