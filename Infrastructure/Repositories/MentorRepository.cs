
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddMentorAsync(Mentor mentor)
    {
        using var conn = _context.Connection();

        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";

        var res = await conn.ExecuteAsync(query, mentor);

        return res > 0;
    }

    public async Task<bool> DeleteMentorAsync(int mentorId)
    {
        using var conn = _context.Connection();

        var query = "delete from mentors where mentorid=@mentorId";

        var res = await conn.ExecuteAsync(query, new { mentorId });

        return res > 0;
    }

    public async Task<Mentor> GetMentorAsync(int mentorId)
    {
        using var conn = _context.Connection();

        var query = "select * from mentors where mentorid=@mentorId";

        var res = await conn.QuerySingleAsync<Mentor>(query, new { mentorId });

        return res;
    }

    public async Task<List<Mentor>> GetMentorsAsync()
    {
        using var conn = _context.Connection();

        var query = "select * from mentors";

        var res = await conn.QueryAsync<Mentor>(query);

        return res.ToList();
    }

    public async Task<bool> UpdateMentorAsync(Mentor mentor)
    {
        using var conn = _context.Connection();

        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";

        var res = await conn.ExecuteAsync(query, mentor);

        return res > 0;
    }
}
