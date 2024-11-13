using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Innovatech.Api.Controllers;

/// <summary>
/// Controller Class base controller api, contain property IMediator
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : Controller
{
    protected IMediator Mediator;
    public ApiBaseController(IMediator _mediator) => Mediator = _mediator;
}
