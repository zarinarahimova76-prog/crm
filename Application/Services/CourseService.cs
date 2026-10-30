
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private ICourseRepository _repo = courseRepository;

    public async Task AddCourseAsync(Course course)
    {
        var result = await _repo.AddCourseAsync(course);

        if (result)
            Console.WriteLine("Added successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var result = await _repo.UpdateCourseAsync(course);

        if (result)
            Console.WriteLine("Updated successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var result = await _repo.DeleteCourseAsync(courseId);

        if (result)
            Console.WriteLine("Deleted successfully!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task GetCourseAsync(int courseId)
    {
        var course = await _repo.GetCourseAsync(courseId);

        Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
    }

    public async Task GetAllCoursesAsync()
    {
        var courses = await _repo.GetCoursesAsync();

        foreach (var course in courses)
        {
            Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
        }
    }
}
