global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Profiles
{
    internal class MeasuredVariableMapping : Profile
    {
        public MeasuredVariableMapping()
        {
            CreateMap<MeasuredVariable, CommandMeasuredVariable>();
            CreateMap<CommandMeasuredVariable, MeasuredVariable>();
            CreateMap<AddMeasuredVariable, MeasuredVariable>();
            CreateMap<CommandMeasuredVariable, AddMeasuredVariable>();
        }
    }
}
