using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    Task<bool> AddStudentToGroupAsync(StudentGroup studentGroup);
    Task<bool> UpdateStudentGroupStatusAsync(int studentId, int groupId, string status);
    Task<bool> RemoveStudentFromGroupAsync(int studentId, int groupId);
    Task<List<StudentGroup>> GetStudentsByGroupAsync(int groupId);
}