
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private IStudentRepository _repository = studentRepository;

    public async Task AddStudentAsync(Student student)
    {
        var result = await _repository.AddStudentAsync(student);

        if (result)
            Console.WriteLine("Added successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var result = await _repository.DeleteStudentAsync(studentId);

        if (result)
            Console.WriteLine("Deleted successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllStudentsAsync()
    {
        var students = await _repository.GetStudentsAsync();

        foreach (var student in students)
        {
            Console.WriteLine(
                $"{student.StudentId} {student.Fullname} {student.Email} {student.Phone} {student.EnrollmentDate}");
        }
    }

    public async Task GetStudentAsync(int studentId)
    {
        var student = await _repository.GetStudentAsync(studentId);

        Console.WriteLine(
            $"{student.StudentId} {student.Fullname} {student.Email} {student.Phone} {student.EnrollmentDate}");
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var result = await _repository.UpdateStudentAsync(student);

        if (result)
            Console.WriteLine("Updated successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }
}
