using Innovatech.Application.Model;
using Innovatech.Application.Task.Commands;
using Innovatech.Application.Task.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Innovatech.Api.Controllers;

/// <summary>
/// Controller Class for Module Task
/// </summary>
/// <param name="_mediator"></param>
public class TaskController(IMediator _mediator) : ApiBaseController(_mediator)
{
    /// <summary>
    /// Method for create item Task
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<bool>> Post(CrateTaskCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    /// <summary>
    /// Method for Update item Task
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<bool>> Put(UpdateTaskCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    /// <summary>
    /// Method for Delete item Task
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(DeleteTaskCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    /// <summary>
    /// Method for Get list Task
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> Get()
    {
        var response = await Mediator.Send(new ListTaskQuery());
        return Ok(response);
    }
}