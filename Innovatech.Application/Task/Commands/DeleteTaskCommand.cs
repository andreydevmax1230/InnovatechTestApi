using Innovatech.Application.Mapper;
using Innovatech.Domain.Repositories;
using Innovatech.Domain.UnitOfWork;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Innovatech.Application.Task.Commands;

/// <summary>
/// Command request wich represent data for delete task
/// </summary>
public class DeleteTaskCommand : IRequest<bool>
{
    [Required(ErrorMessage = "The field ({0}) is required.")]
    public Guid Id { get; set; }
}

/// <summary>
/// Handler (Logic) for delete task from DataBase
/// </summary>
/// <param name="_taskRepository"></param>
/// <param name="_unitOfWork"></param>
internal sealed class DeleteTaskCommandHandler(IRepository<Domain.Entities.Task> _taskRepository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTaskCommand, bool>
{
    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var getEntity = _taskRepository.GetById(request.Id);
        if (getEntity is null)
            throw new NullReferenceException($"The entity with: {request.Id} not exist");
        _taskRepository.Delete(x => x.Id == request.Id);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return response > 0;
    }
}