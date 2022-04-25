using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class SchoolRepository : RepositoryBase<School>, ISchoolRepository
{
	public SchoolRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public IEnumerable<School> GetAllSchools(bool trackChanges) =>
		FindAll(trackChanges)
		.OrderBy(c => c.Name)
		.ToList();

	public School GetSchool(Guid schoolId, bool trackChanges) =>
		FindByCondition(c => c.Id.Equals(schoolId), trackChanges)
		.SingleOrDefault();
}
