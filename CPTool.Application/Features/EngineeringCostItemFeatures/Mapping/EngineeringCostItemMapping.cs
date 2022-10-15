



using CPTool.Application.Features.EngineeringCostItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Mapping
{
    internal class EngineeringCostItemMapping : Profile
    {
        public EngineeringCostItemMapping()
        {
            CreateMap<EngineeringCostItem, EditEngineeringCostItem>();
           

            CreateMap<EditEngineeringCostItem, EngineeringCostItem>();
            CreateMap<AddEngineeringCostItem, EngineeringCostItem>();
        }
    }
}
