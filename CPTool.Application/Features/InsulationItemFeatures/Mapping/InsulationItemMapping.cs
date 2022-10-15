



using CPTool.Application.Features.InsulationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Mapping
{
    internal class InsulationItemMapping : Profile
    {
        public InsulationItemMapping()
        {
            CreateMap<InsulationItem, EditInsulationItem>();
           

            CreateMap<EditInsulationItem, InsulationItem>();
            CreateMap<AddInsulationItem, InsulationItem>();
        }
    }
}
