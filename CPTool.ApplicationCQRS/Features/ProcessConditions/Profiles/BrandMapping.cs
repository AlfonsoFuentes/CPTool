global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Profiles
{
    internal class ProcessConditionMapping : Profile
    {
        public ProcessConditionMapping()
        {
            CreateMap<ProcessCondition, CommandProcessCondition>();
            CreateMap<CommandProcessCondition, ProcessCondition>();
            CreateMap<AddProcessCondition, ProcessCondition>();
            CreateMap<CommandProcessCondition, AddProcessCondition>();
        }
    }
}
