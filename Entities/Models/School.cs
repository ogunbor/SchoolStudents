using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class School
{
	[Column("SchoolId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "School name is a required field.")]
	[MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "School address is a required field.")]
	[MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
	public string? Address { get; set; }

	public string? State { get; set; }

	public ICollection<Student>? Students { get; set; }
}
