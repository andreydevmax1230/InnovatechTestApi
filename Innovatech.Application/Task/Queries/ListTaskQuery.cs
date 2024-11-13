using Innovatech.Application.Mapper;
using Innovatech.Application.Model;
using Innovatech.Domain.Repositories;
using MediatR;

namespace Innovatech.Application.Task.Queries;

/// <summary>
/// Command request wich represent data for get list Task
/// </summary>
public class ListTaskQuery: IRequest<List<TaskDto>>
{
}

/// <summary>
/// Handler (Logic) for get list task from DataBase
/// </summary>
/// <param name="_taskRepository"></param>
internal sealed class ListTaskQueryHandler(IRepository<Domain.Entities.Task> _taskRepository) : IRequestHandler<ListTaskQuery, List<TaskDto>>
{
    public async Task<List<TaskDto>> Handle(ListTaskQuery request, CancellationToken cancellationToken)
    {
        var list = _taskRepository.GetAll();
        var response = MapperConfig.Mapper.Map<List<TaskDto>>(list);
        return await System.Threading.Tasks.Task.FromResult(response);
    }
}