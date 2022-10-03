



using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLPFeatures.Mapping
{
    internal class TaxCodeLPMapping : Profile
    {
        public TaxCodeLPMapping()
        {
            CreateMap<TaxCodeLP, AddEditTaxCodeLPCommand>();

            CreateMap<AddEditTaxCodeLPCommand, TaxCodeLP>();
        }
    }
}
