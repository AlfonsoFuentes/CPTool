global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Profiles
{
    internal class SupplierMapping : Profile
    {
        public SupplierMapping()
        {
            CreateMap<Supplier, CommandSupplier>();
            CreateMap<CommandSupplier, Supplier>();
            CreateMap<AddSupplier, Supplier>();
            CreateMap<CommandSupplier, AddSupplier>();
        }
    }
}
