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

        public SchoolDto CreateSchool(SchoolForCreationDto school)
        {
            var schoolEntity = _mapper.Map<School>(school);

            _repository.School.CreateSchool(schoolEntity);
            _repository.Save();

            return _mapper.Map<SchoolDto>(schoolEntity);
           
        }

        public IEnumerable<SchoolDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var schoolEntities = _repository.School.GetByIds(ids, trackChanges);
            if (ids.Count() != schoolEntities.Count())
                throw new CollectionByIdsBadRequestException();

           return _mapper.Map<IEnumerable<SchoolDto>>(schoolEntities);

        }

        public (IEnumerable<SchoolDto> schools, string ids) CreateSchoolCollection
        (IEnumerable<SchoolForCreationDto> schoolCollection)
        {
            if (schoolCollection is null)
                throw new SchoolCollectionBadRequest();

            var schoolEntities = _mapper.Map<IEnumerable<School>>(schoolCollection);
            foreach (var school in schoolEntities)
            {
                _repository.School.CreateSchool(school);
            }

            _repository.Save();

            var schoolCollectionToReturn = _mapper.Map<IEnumerable<SchoolDto>>(schoolEntities);
            var ids = string.Join(",", schoolCollectionToReturn.Select(c => c.Id));

            return (schools: schoolCollectionToReturn, ids: ids);
      
        }

        public void DeleteSchool(Guid schoolId, bool trackChanges)
        {
            var school = _repository.School.GetSchool(schoolId, trackChanges);
            if (school is null)
                throw new SchoolNotFoundException(schoolId);

            _repository.School.DeleteSchool(school);
            _repository.Save();
        }

        public void UpdateSchool(Guid schoolId, SchoolForUpdateDto schoolForUpdate, bool trackChanges)
        {
            var schoolEntity = _repository.School.GetSchool(schoolId, trackChanges);
            if (schoolEntity is null)
                throw new SchoolNotFoundException(schoolId);

            _mapper.Map(schoolForUpdate, schoolEntity);
            _repository.Save();
        }

    }

    
}
