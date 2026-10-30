using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddGroupAsync(Group group)
    {
        using var connection = _context.Connection();

        var sql = """
            insert into "Groups" (groupname, courseid, mentorid, startdate, enddate)
            values (@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)
            """;

        var result = await connection.ExecuteAsync(sql, group);

        return result > 0;
    }

    public async Task<bool> UpdateGroupAsync(Group group)
    {
        using var connection = _context.Connection();

        var sql = """
            update "Groups"
            set groupname = @GroupName,
                courseid = @CourseId,
                mentorid = @MentorId,
                startdate = @StartDate,
                enddate = @EndDate
            where groupid = @GroupId
            """;

        var result = await connection.ExecuteAsync(sql, group);

        return result > 0;
    }

    public async Task<bool> DeleteGroupAsync(int groupId)
    {
        using var connection = _context.Connection();

        var sql = """
            delete from "Groups"
            where groupid = @GroupId
            """;

        var result = await connection.ExecuteAsync(sql, new { GroupId = groupId });

        return result > 0;
    }

    public async Task<Group> GetGroupAsync(int groupId)
    {
        using var connection = _context.Connection();

        var sql = """
            select groupid as GroupId,
                   groupname as GroupName,
                   courseid as CourseId,
                   mentorid as MentorId,
                   startdate as StartDate,
                   enddate as EndDate
            from "Groups"
            where groupid = @GroupId
            """;

        return await connection.QuerySingleAsync<Group>(
            sql, new { GroupId = groupId });
    }

    public async Task<List<Group>> GetGroupsAsync()
    {
        using var connection = _context.Connection();

        var sql = """
            select groupid as GroupId,
                   groupname as GroupName,
                   courseid as CourseId,
                   mentorid as MentorId,
                   startdate as StartDate,
                   enddate as EndDate
            from "Groups"
            order by groupid
            """;

        var result = await connection.QueryAsync<Group>(sql);

        return result.ToList();
    }
}