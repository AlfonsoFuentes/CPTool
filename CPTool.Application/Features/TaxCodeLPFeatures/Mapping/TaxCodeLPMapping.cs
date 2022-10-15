



using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLPFeatures.Mapping
{
    internal class TaxCodeLPMapping : Profile
    {
        public TaxCodeLPMapping()
        {
            CreateMap<TaxCodeLP, EditTaxCodeLP>();

            CreateMap<EditTaxCodeLP, TaxCodeLP>(); 
            CreateMap<AddTaxCodeLP, TaxCodeLP>();
        }
    }
}
