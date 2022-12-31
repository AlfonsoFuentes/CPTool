global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Profiles
{
    internal class MeasuredVariableModifierMapping : Profile
    {
        public MeasuredVariableModifierMapping()
        {
            CreateMap<MeasuredVariableModifier, CommandMeasuredVariableModifier>();
            CreateMap<CommandMeasuredVariableModifier, MeasuredVariableModifier>();
            CreateMap<AddMeasuredVariableModifier, MeasuredVariableModifier>();
            CreateMap<CommandMeasuredVariableModifier, AddMeasuredVariableModifier>();
        }
    }
}
