
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository _repo = mentorRepository;

    public async Task AddMentorAsync(Mentor mentor)
    {
        var res = await _repo.AddMentorAsync(mentor);

        if (res)
            Console.WriteLine("Added!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var res = await _repo.DeleteMentorAsync(mentorId);

        if (res)
            Console.WriteLine("Deleted!");
        else
            Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllMentorsAsync()
    {
        var mentors = await _repo.GetMentorsAsync();

        foreach (var mentor in mentors)
        {
            Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
        }
    }

    public async Task GetMentorAsync(int mentorId)
    {
        var mentor = await _repo.GetMentorAsync(mentorId);

        Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
    }

    public async Task UpdateMentorAsync(Mentor mentor)
    {
        var res = await _repo.UpdateMentorAsync(mentor);

        if (res)
            Console.WriteLine("Updated!");
        else
            Console.WriteLine("Something went wrong!");
    }
}
