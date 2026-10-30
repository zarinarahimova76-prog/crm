
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddCourseAsync(Course course)
    {
        using var conn = _context.Connection();

        var query = "insert into courses(title, description, durationweeks) values(@title, @description, @durationweeks)";

        var result = await conn.ExecuteAsync(query, course);

        return result > 0;
    }

    public async Task<bool> UpdateCourseAsync(Course course)
    {
        using var conn = _context.Connection();

        var query = "update courses set title=@title, description=@description, durationweeks=@durationweeks where courseid=@courseid";

        var result = await conn.ExecuteAsync(query, course);

        return result > 0;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        using var conn = _context.Connection();

        var query = "delete from courses where courseid=@courseId";

        var result = await conn.ExecuteAsync(query, new { courseId });

        return result > 0;
    }

    public async Task<Course> GetCourseAsync(int courseId)
    {
        using var conn = _context.Connection();

        var query = "select * from courses where courseid=@courseId";

        var result = await conn.QuerySingleAsync<Course>(query, new { courseId });

        return result;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        using var conn = _context.Connection();

        var query = "select * from courses";

        var result = await conn.QueryAsync<Course>(query);

        return result.ToList();
    }
}
