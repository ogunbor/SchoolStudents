using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
	public StudentRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}
}
