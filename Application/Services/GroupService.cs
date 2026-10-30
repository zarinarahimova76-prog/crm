using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task AddGroupAsync(Group group)
    {
        var result = await _groupRepository.AddGroupAsync(group);

        Console.WriteLine(result
            ? "Группа успешно добавлена."
            : "Не удалось добавить группу.");
    }

    public async Task UpdateGroupAsync(Group group)
    {
        var result = await _groupRepository.UpdateGroupAsync(group);

        Console.WriteLine(result
            ? "Группа успешно обновлена."
            : "Группа не найдена.");
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var result = await _groupRepository.DeleteGroupAsync(groupId);

        Console.WriteLine(result
            ? "Группа успешно удалена."
            : "Группа не найдена.");
    }

    public async Task GetGroupAsync(int groupId)
    {
        var group = await _groupRepository.GetGroupAsync(groupId);

        Console.WriteLine(
            $"ID: {group.GroupId}, Название: {group.GroupName}, " +
            $"Курс: {group.CourseId}, Наставник: {group.MentorId}, " +
            $"Начало: {group.StartDate}, Конец: {group.EndDate}");
    }

    public async Task GetGroupsAsync()
    {
        var groups = await _groupRepository.GetGroupsAsync();

        foreach (var group in groups)
        {
            Console.WriteLine(
                $"ID: {group.GroupId}, Название: {group.GroupName}, " +
                $"Курс: {group.CourseId}, Наставник: {group.MentorId}, " +
                $"Начало: {group.StartDate}, Конец: {group.EndDate}");
        }
    }
}