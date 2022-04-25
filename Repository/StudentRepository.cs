using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
	public StudentRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public IEnumerable<Student> GetStudents(Guid schoolId, bool trackChanges) =>
		FindByCondition(e => e.SchoolId.Equals(schoolId), trackChanges)
		.OrderBy(e => e.Name)
		.ToList();

	public Student GetStudent(Guid schoolId, Guid id, bool trackChanges) =>
		FindByCondition(e => e.SchoolId.Equals(schoolId) && e.Id.Equals(id), trackChanges)
		.SingleOrDefault();

	public void CreateStudentForSchool(Guid schoolId, Student student)
	{
		student.SchoolId = schoolId; Create(student);
	}
}
