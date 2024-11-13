using Bogus;
using Innovatech.Application.Task.Commands;

namespace Innovatech.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for Delete task test
/// </summary>
internal static class DeleteTaskFake
{
    public static DeleteTaskCommand GenerateItemFake(this Faker<DeleteTaskCommand> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        return item.Generate();
    }
}
