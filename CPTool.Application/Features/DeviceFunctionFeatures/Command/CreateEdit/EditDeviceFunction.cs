namespace CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit
{
    public class EditDeviceFunction : EditCommand, IRequest<Result<int>>
    {

        [Report(Order = 3)]
        public string? TagLetter { get; set; }

    }
}
