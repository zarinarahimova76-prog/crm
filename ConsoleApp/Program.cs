using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var appDbContext = new AppDbContext();
var studentRepository = new StudentRepository(appDbContext);
var studentService = new StudentService(studentRepository);
var mentorRepository = new MentorRepository(appDbContext);
var mentorService = new MentorService(mentorRepository);
var courseRepository = new CourseRepository(appDbContext);
var courseService = new CourseService(courseRepository);
var groupRepository = new GroupRepository(appDbContext);
var groupService = new GroupService(groupRepository);

while (true)
{
    Console.WriteLine("==================================");
Console.WriteLine(@"1 - Show all students.
2 - Show student.
3 - Add new student.
4 - Update student.
5 - Delete student.
6 - Show all mentors.
7 - Show mentor.
8 - Add new mentor.
9 - Update mentor.
10 - Delete mentor.
11 - Show all courses.
12 - Show course.
13 - Add new course.
14 - Update course.
15 - Delete course.
16 - Show all groups.
17 - Show group.
18 - Add new group.
19 - Update group.
20 - Delete group.
0 - Exit.");
    var option = Console.ReadLine();
    Console.WriteLine("==================================");

    switch (option)
    {
        case "1":
            await studentService.GetAllStudentsAsync();
            break;

        case "2":
            Console.Write("Enter id: ");
            var studentId = Convert.ToInt32(Console.ReadLine());

            await studentService.GetStudentAsync(studentId);
            break;

        case "3":
            Console.Write("Enter fullname: ");
            var fullname = Console.ReadLine()!;

            Console.Write("Enter email: ");
            var email = Console.ReadLine();

            Console.Write("Enter phone: ");
            var phone = Console.ReadLine()!;

            Console.Write("Enter enrollment date: ");
            var enrollmentDate = Convert.ToDateTime(Console.ReadLine());

            var student = new Student()
            {
                Fullname = fullname,
                Email = email,
                Phone = phone,
                EnrollmentDate = DateOnly.FromDateTime(enrollmentDate)
            };

            await studentService.AddStudentAsync(student);
            break;

        case "4":
            Console.Write("Enter id: ");
            var uStudentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter fullname: ");
            var uFullname = Console.ReadLine()!;

            Console.Write("Enter email: ");
            var uEmail = Console.ReadLine();

            Console.Write("Enter phone: ");
            var uPhone = Console.ReadLine()!;

            Console.Write("Enter enrollment date: ");
            var uEnrollmentDate = Convert.ToDateTime(Console.ReadLine());

            var uStudent = new Student()
            {
                StudentId = uStudentId,
                Fullname = uFullname,
                Email = uEmail,
                Phone = uPhone,
                EnrollmentDate = DateOnly.FromDateTime(uEnrollmentDate)
            };

            await studentService.UpdateStudentAsync(uStudent);
            break;

        case "5":
            Console.Write("Enter id: ");
            var dStudentId = Convert.ToInt32(Console.ReadLine());

            await studentService.DeleteStudentAsync(dStudentId);
            break;


case "6":
    await mentorService.GetAllMentorsAsync();
    break;

case "7":
    Console.Write("Enter mentor id: ");
    var mentorId = Convert.ToInt32(Console.ReadLine());

    await mentorService.GetMentorAsync(mentorId);
    break;

case "8":
    Console.Write("Enter fullname: ");
    var mFullname = Console.ReadLine()!;

    Console.Write("Enter email: ");
    var mEmail = Console.ReadLine();

    Console.Write("Enter phone: ");
    var mPhone = Console.ReadLine()!;

    Console.Write("Enter specialization: ");
    var specialization = Console.ReadLine()!;

    var mentor = new Mentor()
    {
        Fullname = mFullname,
        Email = mEmail,
        Phone = mPhone,
        Specialization = specialization
    };

    await mentorService.AddMentorAsync(mentor);
    break;

   case "9":
    Console.Write("Enter mentor id: ");
    var uMentorId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter fullname: ");
    var umFullname = Console.ReadLine()!;

    Console.Write("Enter email: ");
    var umEmail = Console.ReadLine();

    Console.Write("Enter phone: ");
    var umPhone = Console.ReadLine()!;

    Console.Write("Enter specialization: ");
    var uSpecialization = Console.ReadLine()!;

    var uMentor = new Mentor()
    {
        MentorId = uMentorId,
        Fullname = umFullname,
        Email = umEmail,
        Phone = umPhone,
        Specialization = uSpecialization
    };

    await mentorService.UpdateMentorAsync(uMentor);
    break;

case "10":
    Console.Write("Enter mentor id: ");
    var dMentorId = Convert.ToInt32(Console.ReadLine());

    await mentorService.DeleteMentorAsync(dMentorId);
    break;


   
case "11":
    await courseService.GetAllCoursesAsync();
    break;

case "12":
    Console.Write("Enter course id: ");
    var courseId = Convert.ToInt32(Console.ReadLine());

    await courseService.GetCourseAsync(courseId);
    break;

case "13":
    Console.Write("Enter title: ");
    var title = Console.ReadLine()!;

    Console.Write("Enter description: ");
    var description = Console.ReadLine();

    Console.Write("Enter duration in weeks: ");
    var durationWeeks = Convert.ToInt32(Console.ReadLine());

    var course = new Course()
    {
        Title = title,
        Description = description,
        DurationWeeks = durationWeeks
    };

    await courseService.AddCourseAsync(course);
    break;

case "14":
    Console.Write("Enter course id: ");
    var uCourseId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter title: ");
    var uTitle = Console.ReadLine()!;

    Console.Write("Enter description: ");
    var uDescription = Console.ReadLine();

    Console.Write("Enter duration in weeks: ");
    var uDurationWeeks = Convert.ToInt32(Console.ReadLine());

    var uCourse = new Course()
    {
        CourseId = uCourseId,
        Title = uTitle,
        Description = uDescription,
        DurationWeeks = uDurationWeeks
    };

    await courseService.UpdateCourseAsync(uCourse);
    break;

case "15":
    Console.Write("Enter course id: ");
    var dCourseId = Convert.ToInt32(Console.ReadLine());

    await courseService.DeleteCourseAsync(dCourseId);
    break;


case "16":
    await groupService.GetGroupsAsync();
    break;

case "17":
    Console.Write("Enter group id: ");
    var groupId = Convert.ToInt32(Console.ReadLine());

    await groupService.GetGroupAsync(groupId);
    break;

case "18":
    Console.Write("Enter group name: ");
    var groupName = Console.ReadLine()!;

    Console.Write("Enter course id: ");
    var gCourseId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter mentor id: ");
    var gMentorId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter start date (yyyy-MM-dd): ");
    var startDate = DateOnly.Parse(Console.ReadLine()!);

    Console.Write("Enter end date (yyyy-MM-dd): ");
    var endDate = DateOnly.Parse(Console.ReadLine()!);

    var group = new Group()
    {
        GroupName = groupName,
        CourseId = gCourseId,
        MentorId = gMentorId,
        StartDate = startDate,
        EndDate = endDate
    };

    await groupService.AddGroupAsync(group);
    break;

case "19":
    Console.Write("Enter group id: ");
    var uGroupId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter group name: ");
    var uGroupName = Console.ReadLine()!;

    Console.Write("Enter course id: ");
    var uGCourseId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter mentor id: ");
    var uGMentorId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter start date (yyyy-MM-dd): ");
    var uStartDate = DateOnly.Parse(Console.ReadLine()!);

    Console.Write("Enter end date (yyyy-MM-dd): ");
    var uEndDate = DateOnly.Parse(Console.ReadLine()!);

    var uGroup = new Group()
    {
        GroupId = uGroupId,
        GroupName = uGroupName,
        CourseId = uGCourseId,
        MentorId = uGMentorId,
        StartDate = uStartDate,
        EndDate = uEndDate
    };

    await groupService.UpdateGroupAsync(uGroup);
    break;


    case "20":
    Console.Write("Enter group id: ");
    var dGroupId = Convert.ToInt32(Console.ReadLine());

    await groupService.DeleteGroupAsync(dGroupId);
    break;

        case "0":
            Console.WriteLine("Exiting...");
            return;
    }
}
