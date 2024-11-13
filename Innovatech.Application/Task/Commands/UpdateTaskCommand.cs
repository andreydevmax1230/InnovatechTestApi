using Innovatech.Application.Mapper;
using Innovatech.Domain.Repositories;
using Innovatech.Domain.UnitOfWork;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Innovatech.Application.Task.Commands;

/// <summary>
/// Command request wich represent data for update Task
/// </summary>
public class UpdateTaskCommand : IRequest<bool>
{
    [Required(ErrorMessage = "The field ({0}) is required.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required.")]
    [MaxLength(128, ErrorMessage = "the maximum length for the field: ({0}) is: ({1}) characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required")]
    [MaxLength(256, ErrorMessage = "the maximum length for the field: ({0}) is: ({1}) characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required")]
    [DataType(DataType.Date, ErrorMessage = "The field ({0}) must be DateTime")]
    public DateTime DateCompleted { get; set; }
    public bool Active { get; set; }
}

/// <summary>
/// Handler (Logic) for update task from DataBase
/// </summary>
/// <param name="_taskRepository"></param>
/// <param name="_unitOfWork"></param>
internal sealed class UpdateTaskCommandHandler(IRepository<Domain.Entities.Task> _taskRepository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateTaskCommand, bool>
{
    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var getEntity = _taskRepository.GetEntityNotTracking(x => x.Id == request.Id);
        if(getEntity is null)
            throw new NullReferenceException($"The entity with: {request.Id} not exist");
        var entity = MapperConfig.Mapper.Map<Domain.Entities.Task>(request);
        if (entity is null)
            throw new ApplicationException("There is a problem in mapper");
        _taskRepository.Update(entity);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return response > 0;
    }
}