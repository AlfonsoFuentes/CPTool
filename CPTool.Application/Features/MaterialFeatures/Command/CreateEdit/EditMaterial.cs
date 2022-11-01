using CPTool.Application.Features.GasketFeatures.Query.GetById;
using CPTool.Application.Features.GasketFeatures.Query.GetList;
using CPTool.Application.Features.MaterialFeatures.Query.GetById;
using CPTool.Application.Features.MaterialFeatures.Query.GetList;

namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    public class EditMaterial : EditCommand, IRequest<Result<int>>
    {
        public string? Abbreviation { get; set; }

      



    }
}
