using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Student
{
	[Column("StudentId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Student's name is a required field.")]
	[MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "Age is a required field.")]
	public int Age { get; set; }

	[Required(ErrorMessage = "Position is a required field.")]
	[MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
	public string? Year { get; set; }

	[ForeignKey(nameof(School))]
	public Guid SchoolId { get; set; }
	public School? School { get; set; }
}
