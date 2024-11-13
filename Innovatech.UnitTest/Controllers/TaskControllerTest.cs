using Bogus;
using Innovatech.Api.Controllers;
using Innovatech.Application.Model;
using Innovatech.Application.Task.Commands;
using Innovatech.Application.Task.Queries;
using Innovatech.UnitTest.Fake;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace Innovatech.UnitTest.Controllers;

/// <summary>
/// Class for test methods of TaskController
/// </summary>
[TestFixture]
public  class TaskControllerTest 
{

    [Fact]
    public async Task Post()
    {
        var request = new Faker<CrateTaskCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(true);
        mediador.Setup(m => m.Send(It.IsAny<CrateTaskCommand>(), default(CancellationToken))).Returns(response);
        var controller = new TaskController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Post(request)).Result).Value;
        Xunit.Assert.True((bool)result);
    }

    [Fact]
    public async Task Put()
    {
        var request = new Faker<UpdateTaskCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(true);
        mediador.Setup(m => m.Send(It.IsAny<UpdateTaskCommand>(), default(CancellationToken))).Returns(response);
        var controller = new TaskController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Put(request)).Result).Value;
        Xunit.Assert.True((bool)result);
    }

    [Fact]
    public async Task Delete()
    {
        var request = new Faker<DeleteTaskCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(true);
        mediador.Setup(m => m.Send(It.IsAny<DeleteTaskCommand>(), default(CancellationToken))).Returns(response);
        var controller = new TaskController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Delete(request)).Result).Value;
        Xunit.Assert.True((bool)result);
    }

    [Fact]
    public async Task Get()
    {
        var response = Task.FromResult(new Faker<TaskDto>().ListTaskFaker());
        Mock<IMediator> mediador = new();
        mediador.Setup(m => m.Send(It.IsAny<ListTaskQuery>(), default(CancellationToken))).Returns(response);
        var controller = new TaskController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Get()).Result).Value as List<TaskDto>;
        Xunit.Assert.IsType<List<TaskDto>>(result);
        Xunit.Assert.NotEmpty(result);
    }
}
