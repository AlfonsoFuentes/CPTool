



using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Mapping
{
    internal class UnitaryBasePrizeMapping : Profile
    {
        public UnitaryBasePrizeMapping()
        {
            CreateMap<UnitaryBasePrize,EditUnitaryBasePrize>();

            CreateMap<EditUnitaryBasePrize, UnitaryBasePrize>();
            CreateMap<AddUnitaryBasePrize, UnitaryBasePrize>();
        }
    }
}
