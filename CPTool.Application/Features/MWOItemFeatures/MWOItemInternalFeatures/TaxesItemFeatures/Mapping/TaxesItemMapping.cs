using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TaxesItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TaxesItemFeatures.Mapping
{
    internal class TaxesItemMapping : Profile
    {
        public TaxesItemMapping()
        {
            CreateMap<TaxesItem, AddEditTaxesItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditTaxesItemCommand, TaxesItem>();
        }
    }

}
