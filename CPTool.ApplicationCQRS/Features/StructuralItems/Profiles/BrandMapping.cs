global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Profiles
{
    internal class StructuralItemMapping : Profile
    {
        public StructuralItemMapping()
        {
            CreateMap<StructuralItem, CommandStructuralItem>();
            CreateMap<CommandStructuralItem, StructuralItem>();
            CreateMap<AddStructuralItem, StructuralItem>();
            CreateMap<CommandStructuralItem, AddStructuralItem>();
        }
    }
}
