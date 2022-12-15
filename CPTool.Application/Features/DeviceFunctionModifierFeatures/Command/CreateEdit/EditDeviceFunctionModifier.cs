

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    public class EditDeviceFunctionModifier : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string? TagLetter { get; set; }


    }
}
