





using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit
{
    public class EditMeasuredVariableModifier : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string? TagLetter { get; set; }

    }


}
