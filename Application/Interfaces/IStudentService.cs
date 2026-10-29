using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int studentId);
    void GetStudent(int studentId);
    void GetAllStudents();
}