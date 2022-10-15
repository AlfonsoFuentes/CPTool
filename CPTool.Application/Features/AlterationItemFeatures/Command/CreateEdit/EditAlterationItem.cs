





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.AlterationItemFeatures.CreateEdit
{
    public class EditAlterationItem : EditCommand/*, IRequest<Result<int>>*/
    {

        public string CostCenter { get; set; } = null!;
       
    }
}
