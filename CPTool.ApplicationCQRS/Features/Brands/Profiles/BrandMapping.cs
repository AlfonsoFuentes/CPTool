global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Brands.Profiles
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, CommandBrand>();
            CreateMap<CommandBrand, Brand>();
            CreateMap<AddBrand, Brand>();
            CreateMap<CommandBrand, AddBrand>();
        }
    }
}
