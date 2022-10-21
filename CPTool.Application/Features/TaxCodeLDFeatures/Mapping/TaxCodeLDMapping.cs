



using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLDFeatures.Mapping
{
    internal class TaxCodeLDMapping : Profile
    {
        public TaxCodeLDMapping()
        {
            CreateMap<TaxCodeLD, EditTaxCodeLD>();
            CreateMap<EditTaxCodeLD, TaxCodeLD>();
            CreateMap<AddTaxCodeLD, TaxCodeLD>();
            CreateMap<EditTaxCodeLD, AddTaxCodeLD>();
        }
    }
}
