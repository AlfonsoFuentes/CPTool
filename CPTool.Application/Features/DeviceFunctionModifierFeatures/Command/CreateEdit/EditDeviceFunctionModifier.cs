namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    public class EditDeviceFunctionModifier : EditCommand, IRequest<Result<int>>
    {

        public string? TagLetter { get; set; }


    }
}
