



using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLDFeatures.Mapping
{
    internal class TaxCodeLDMapping : Profile
    {
        public TaxCodeLDMapping()
        {
            CreateMap<TaxCodeLD, AddEditTaxCodeLDCommand>();

            CreateMap<AddEditTaxCodeLDCommand, TaxCodeLD>();
        }
    }
}
