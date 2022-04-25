

using Entities.Models;

namespace Contracts
{
    public interface ISchoolRepository
    {
        IEnumerable<School> GetAllSchools(bool trackChanges);
        School GetSchool(Guid schoolId, bool trackChanges);
    }
}
