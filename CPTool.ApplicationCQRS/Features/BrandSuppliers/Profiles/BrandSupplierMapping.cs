global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Profiles
{
    internal class BrandSupplierMapping : Profile
    {
        public BrandSupplierMapping()
        {
            CreateMap<BrandSupplier, CommandBrandSupplier>();
            CreateMap<CommandBrandSupplier, BrandSupplier>();
            CreateMap<AddBrandSupplier, BrandSupplier>();
            CreateMap<CommandBrandSupplier, AddBrandSupplier>();
        }
    }
}
