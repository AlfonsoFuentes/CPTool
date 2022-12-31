global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Signals.Profiles
{
    internal class SignalMapping : Profile
    {
        public SignalMapping()
        {
            CreateMap<Signal, CommandSignal>();
            CreateMap<CommandSignal, Signal>();
            CreateMap<AddSignal, Signal>();
            CreateMap<CommandSignal, AddSignal>();
        }
    }
}
