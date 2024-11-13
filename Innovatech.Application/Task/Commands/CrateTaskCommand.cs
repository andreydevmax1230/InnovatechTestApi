using Innovatech.Application.Mapper;
using Innovatech.Domain.Repositories;
using Innovatech.Domain.UnitOfWork;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Innovatech.Application.Task.Commands;

/// <summary>
/// Command request wich represent data for create Task
/// </summary>
public class CrateTaskCommand : IRequest<bool>
{
    [Required(ErrorMessage = "The field ({0}) is required.")]
    [MaxLength(128, ErrorMessage = "the maximum length for the field: ({0}) is: ({1}) characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required")]
    [MaxLength(256, ErrorMessage = "the maximum length for the field: ({0}) is: ({1}) characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required")]
    [DataType(DataType.Date, ErrorMessage = "The field ({0}) must be DateTime")]
    public DateTime DateCompleted { get; set; }

    [Required(ErrorMessage = "The field ({0}) is required")]
    public bool Active { get; set; }
}

/// <summary>
/// Handler (Logic) for create task from DataBase
/// </summary>
/// <param name="_taskRepository"></param>
/// <param name="_unitOfWork"></param>
internal sealed class CrateTaskCommandHandler(IRepository<Domain.Entities.Task> _taskRepository, IUnitOfWork _unitOfWork) : IRequestHandler<CrateTaskCommand, bool>
{
    public async Task<bool> Handle(CrateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = MapperConfig.Mapper.Map<Domain.Entities.Task>(request);
        if (entity is null)
            throw new ApplicationException("There is a problem in mapper");
        entity.Id = Guid.NewGuid();
        _taskRepository.Insert(entity);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return response > 0;
    }
}