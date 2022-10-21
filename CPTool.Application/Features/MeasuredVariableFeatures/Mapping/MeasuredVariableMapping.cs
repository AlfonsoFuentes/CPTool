



using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Mapping
{
    internal class MeasuredVariableMapping : Profile
    {
        public MeasuredVariableMapping()
        {
            CreateMap<MeasuredVariable, EditMeasuredVariable>();

            CreateMap<EditMeasuredVariable, MeasuredVariable>();
            CreateMap<EditMeasuredVariable, AddMeasuredVariable>();
            CreateMap<AddMeasuredVariable, MeasuredVariable>();
        }
    }
}
