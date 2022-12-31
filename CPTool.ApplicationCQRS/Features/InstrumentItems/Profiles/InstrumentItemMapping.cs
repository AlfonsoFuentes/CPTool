global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Profiles
{
    internal class InstrumentItemMapping : Profile
    {
        public InstrumentItemMapping()
        {
            CreateMap<InstrumentItem, CommandInstrumentItem>();
            CreateMap<CommandInstrumentItem, InstrumentItem>();
            CreateMap<AddInstrumentItem, InstrumentItem>();
            CreateMap<CommandInstrumentItem, AddInstrumentItem>();
            CreateMap<CommandInstrumentItem, UpdateInstrumentItem>();
            CreateMap<UpdateInstrumentItem, InstrumentItem>();
        }
    }
}
