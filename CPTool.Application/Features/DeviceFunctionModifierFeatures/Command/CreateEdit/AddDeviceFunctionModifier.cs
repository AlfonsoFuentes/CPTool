





using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    public class AddDeviceFunctionModifier : AddCommand, IRequest<Result<int>>
    {

        public string? TagLetter { get; set; }


    }
}
