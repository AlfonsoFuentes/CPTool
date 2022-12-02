using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

using CPToolRadzen.Pages.PipeDiameter.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeDiameter.List
{
    public partial class PipeDiameterList : BaseTableTemplate<EditPipeDiameter>
    {
        public override List<EditPipeDiameter> Elements => RadzenTables.PipeDiameters.Where(x => x.dPipeClassId == ParentId).ToList();
        EditPipeClass Parent => RadzenTables.PipeClasses.FirstOrDefault(x => x.Id == ParentId);


        protected override void OnInitialized()
        {
            TableName = "Pipe Diameter";

            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditPipeDiameter model)
        {
            if (model.Id == 0)
            {
                model.dPipeClass = Parent;
            }
            var result = await DialogService.OpenAsync<PipeDiameterDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
