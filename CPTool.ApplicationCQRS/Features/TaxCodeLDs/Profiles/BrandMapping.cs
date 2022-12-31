global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Profiles
{
    internal class TaxCodeLDMapping : Profile
    {
        public TaxCodeLDMapping()
        {
            CreateMap<TaxCodeLD, CommandTaxCodeLD>();
            CreateMap<CommandTaxCodeLD, TaxCodeLD>();
            CreateMap<AddTaxCodeLD, TaxCodeLD>();
            CreateMap<CommandTaxCodeLD, AddTaxCodeLD>();
        }
    }
}
