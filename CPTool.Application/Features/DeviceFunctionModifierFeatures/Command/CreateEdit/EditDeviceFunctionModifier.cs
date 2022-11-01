using CPTool.Application.Features.ConnectionTypeFeatures.Query.GetById;
using CPTool.Application.Features.ConnectionTypeFeatures.Query.GetList;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    public class EditDeviceFunctionModifier : EditCommand, IRequest<Result<int>>
    {
       
        public string? TagLetter { get; set; }


    }
}
