using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository): IMentorService
{
    private MentorRepository _repo = mentorRepository;

    public async Task AddMentorAsync(Mentor mentor)
    {
        var res = await _repo.AddMentorAsync(mentor);
        if(res) System.Console.WriteLine("Added!");
        else System.Console.WriteLine("Smth went wrong!");
    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var res = await _repo.DeleteMentorAsync(mentorId);
        if(res) System.Console.WriteLine("Deleted!");
        else System.Console.WriteLine("Smth went wrong!");
    }

    public async Task GetAllMentorsAsync()
    {
        await _repo.GetMentorsAsync();
    }

    public async Task GetMentorAsync(int mentorId)
    {
        await _repo.GetMentorAsync(mentorId);
    }

    public async Task UpdateMentorAsync(Mentor mentor)
    {
        var res = await _repo.UpdateMentorAsync(mentor);
        if(res) System.Console.WriteLine("Updated!");
        else System.Console.WriteLine("Smth went wrong!");
    }

}