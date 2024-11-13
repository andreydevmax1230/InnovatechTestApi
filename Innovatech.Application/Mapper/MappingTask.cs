using AutoMapper;
using Innovatech.Application.Model;
using Innovatech.Application.Task.Commands;

namespace Innovatech.Application.Mapper;

/// <summary>
/// Generate Map for entities DB and Command or Dtos
/// </summary>
internal class MappingTask : Profile
{
    public MappingTask()
    {
        CreateMap<Domain.Entities.Task, TaskDto>().ReverseMap();
        CreateMap<Domain.Entities.Task, CrateTaskCommand>().ReverseMap();
        CreateMap<Domain.Entities.Task, UpdateTaskCommand>().ReverseMap();
    }
}