namespace Shared.DataTransferObjects;

public record SchoolForCreationDto(string Name, string Address, string State,
    IEnumerable<StudentForCreationDto> Students);