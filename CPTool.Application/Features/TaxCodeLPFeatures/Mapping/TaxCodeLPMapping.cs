



using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLPFeatures.Mapping
{
    internal class TaxCodeLPMapping : Profile
    {
        public TaxCodeLPMapping()
        {
            CreateMap<TaxCodeLP, AddEditTaxCodeLPCommand>()
                 .ForMember(dest => dest.SuppliersCommand, act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); }); 

            CreateMap<AddEditTaxCodeLPCommand, TaxCodeLP>();
        }
    }
}
