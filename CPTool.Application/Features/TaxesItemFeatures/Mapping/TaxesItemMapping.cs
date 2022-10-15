



using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Mapping
{
    internal class TaxesItemMapping : Profile
    {
        public TaxesItemMapping()
        {
            CreateMap<TaxesItem, EditTaxesItem>();
            CreateMap<EditTaxesItem, TaxesItem>();
            CreateMap<AddTaxesItem, TaxesItem>();
        }
    }
}
