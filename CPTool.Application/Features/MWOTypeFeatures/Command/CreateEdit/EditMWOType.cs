
using CPTool.Application.Features.MWOFeatures.CreateEdit;

namespace CPTool.Application.Features.MMOTypeFeatures.CreateEdit
{
    public class EditMWOType : EditCommand, IRequest<Result<int>>
    {


        public List<EditMWO> MWOs { get; set; } = null!;
    }

}
