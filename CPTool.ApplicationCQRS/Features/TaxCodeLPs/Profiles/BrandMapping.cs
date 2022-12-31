global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Profiles
{
    internal class TaxCodeLPMapping : Profile
    {
        public TaxCodeLPMapping()
        {
            CreateMap<TaxCodeLP, CommandTaxCodeLP>();
            CreateMap<CommandTaxCodeLP, TaxCodeLP>();
            CreateMap<AddTaxCodeLP, TaxCodeLP>();
            CreateMap<CommandTaxCodeLP, AddTaxCodeLP>();
        }
    }
}
