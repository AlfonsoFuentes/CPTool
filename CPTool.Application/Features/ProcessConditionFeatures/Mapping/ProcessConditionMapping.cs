



using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Mapping
{
    internal class ProcessConditionMapping : Profile
    {
        public ProcessConditionMapping()
        {
            CreateMap<ProcessCondition, EditProcessCondition>();

            CreateMap<EditProcessCondition, ProcessCondition>();
            CreateMap<AddProcessCondition, ProcessCondition>();
            CreateMap<EditProcessCondition, AddProcessCondition>();
        }
    }
}
