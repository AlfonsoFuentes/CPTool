



using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLDFeatures.Mapping
{
    internal class TaxCodeLDMapping : Profile
    {
        public TaxCodeLDMapping()
        {
            CreateMap<TaxCodeLD, AddEditTaxCodeLDCommand>()
                .ForMember(dest => dest.SuppliersCommand, act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); });

            CreateMap<AddEditTaxCodeLDCommand, TaxCodeLD>();
        }
    }
}
