namespace CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit
{
    public class EditDeviceFunction : EditCommand, IRequest<Result<int>>
    {


        public string? TagLetter { get; set; }

    }
}
