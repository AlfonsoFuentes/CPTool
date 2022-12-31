global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Profiles
{
    internal class PaintingItemMapping : Profile
    {
        public PaintingItemMapping()
        {
            CreateMap<PaintingItem, CommandPaintingItem>();
            CreateMap<CommandPaintingItem, PaintingItem>();
            CreateMap<AddPaintingItem, PaintingItem>();
            CreateMap<CommandPaintingItem, AddPaintingItem>();
        }
    }
}
