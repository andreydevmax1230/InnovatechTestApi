using Bogus;
using Innovatech.Application.Model;

namespace Innovatech.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for get list Task
/// </summary>
internal static class ListTaskFake
{
    public static List<TaskDto> ListTaskFaker(this Faker<TaskDto> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        item.RuleFor(x => x.Name, z => z.Lorem.Lines(2));
        item.RuleFor(x => x.Description, z => z.Lorem.Lines(5));
        item.RuleFor(x => x.DateCompleted, z => DateTime.UtcNow);
        item.RuleFor(x => x.Active, z => true);
        return item.Generate(6).ToList();
    }
}
