



using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Mapping
{
    internal class UnitMapping : Profile
    {
        public UnitMapping()
        {
            CreateMap<CPTool.Domain.Entities.Unit, EditUnit>();
            CreateMap<EditUnit, AddUnit>();
            CreateMap<EditUnit, CPTool.Domain.Entities.Unit>();
            CreateMap<AddUnit, CPTool.Domain.Entities.Unit>();
        }
    }
}
