global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Profiles
{
    internal class SignalModifierMapping : Profile
    {
        public SignalModifierMapping()
        {
            CreateMap<SignalModifier, CommandSignalModifier>();
            CreateMap<CommandSignalModifier, SignalModifier>();
            CreateMap<AddSignalModifier, SignalModifier>();
            CreateMap<CommandSignalModifier, AddSignalModifier>();
        }
    }
}
