using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class SchoolService : ISchoolService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SchoolService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<SchoolDto> GetAllSchools(bool trackChanges)
        {
            
                var schools = _repository.School.GetAllSchools(trackChanges);
                var schoolsDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);
                return schoolsDto;

        }

        public SchoolDto GetSchool(Guid id, bool trackChanges)
        {
            var school = _repository.School.GetSchool(id, trackChanges);
            if (school is null)
                throw new SchoolNotFoundException(id);

            var schoolDto = _mapper.Map<SchoolDto>(school);
            return schoolDto;
        }
    }

    
}
