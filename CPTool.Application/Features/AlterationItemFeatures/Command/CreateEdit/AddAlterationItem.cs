





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;


namespace CPTool.Application.Features.AlterationItemFeatures.CreateEdit
{
    public class AddAlterationItem : AddCommand/*, IRequest<Result<int>>*/
    {

        public string? CostCenter { get; set; } = null!;
       
    }
}
