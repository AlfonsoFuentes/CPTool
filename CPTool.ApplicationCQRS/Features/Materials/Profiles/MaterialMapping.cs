global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Materials.Profiles
{
    internal class MaterialMapping : Profile
    {
        public MaterialMapping()
        {
            CreateMap<Material, CommandMaterial>();
            CreateMap<CommandMaterial, Material>();
            CreateMap<AddMaterial, Material>();
            CreateMap<CommandMaterial, AddMaterial>();
        }
    }
}
