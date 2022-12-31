global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Profiles
{
    internal class TaxesItemMapping : Profile
    {
        public TaxesItemMapping()
        {
            CreateMap<TaxesItem, CommandTaxesItem>();
            CreateMap<CommandTaxesItem, TaxesItem>();
            CreateMap<AddTaxesItem, TaxesItem>();
            CreateMap<CommandTaxesItem, AddTaxesItem>();
        }
    }
}
