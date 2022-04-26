namespace Shared.DataTransferObjects;

public record SchoolForUpdateDto(string Name, string Address, string State,
	IEnumerable<StudentForCreationDto> Students);