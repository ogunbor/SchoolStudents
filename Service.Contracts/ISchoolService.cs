
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISchoolService
    {
        IEnumerable<SchoolDto> GetAllSchools(bool trackChanges);
        SchoolDto GetSchool(Guid schoolId, bool trackChanges);

        SchoolDto CreateSchool(SchoolForCreationDto school);
        IEnumerable<SchoolDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        (IEnumerable<SchoolDto> schools, string ids) CreateSchoolCollection
        (IEnumerable<SchoolForCreationDto> schoolCollection);

        void DeleteSchool(Guid schoolId, bool trackChanges);
        void UpdateSchool(Guid schoolid, SchoolForUpdateDto schoolForUpdate, bool trackChanges);
    }
}
