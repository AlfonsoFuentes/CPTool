



using CPTool.Application.Features.TaxesItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Mapping
{
    internal class TaxesItemMapping : Profile
    {
        public TaxesItemMapping()
        {
            CreateMap<TaxesItem, AddEditTaxesItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditTaxesItemCommand, TaxesItem>();
        }
    }
}
