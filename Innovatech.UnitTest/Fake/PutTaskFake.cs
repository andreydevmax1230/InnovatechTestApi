using Bogus;
using Innovatech.Application.Task.Commands;

namespace Innovatech.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for Update task test
/// </summary>
internal static class PutTaskFake
{
    public static UpdateTaskCommand GenerateItemFake(this Faker<UpdateTaskCommand> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        item.RuleFor(x => x.Name, z => "test1");
        item.RuleFor(x => x.Description, z => "description item");
        item.RuleFor(x => x.DateCompleted, z => DateTime.Now);
        item.RuleFor(x => x.Active, z => true);
        return item.Generate();
    }
}
