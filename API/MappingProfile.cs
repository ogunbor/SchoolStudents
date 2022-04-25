using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<School, SchoolDto>()
			.ForMember(c => c.FullAddress,
				opt => opt.MapFrom(x => string.Join(' ', x.Address, x.State)));

			CreateMap<Student, StudentDto>();

			CreateMap<SchoolForCreationDto, School>();

			CreateMap<StudentForCreationDto, Student>();
		}
	}
}
