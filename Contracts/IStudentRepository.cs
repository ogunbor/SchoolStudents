

using Entities.Models;

namespace Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents(Guid studentId, bool trackChanges);
        Student GetStudent(Guid schoolId, Guid id, bool trackChanges);
    }
}
