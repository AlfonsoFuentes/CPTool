



using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Mapping
{
    internal class UnitaryBasePrizeMapping : Profile
    {
        public UnitaryBasePrizeMapping()
        {
            CreateMap<UnitaryBasePrize, AddEditUnitaryBasePrizeCommand>()
                .ForMember(dest => dest.MWOItems, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditUnitaryBasePrizeCommand, UnitaryBasePrize>();
        }
    }
}
