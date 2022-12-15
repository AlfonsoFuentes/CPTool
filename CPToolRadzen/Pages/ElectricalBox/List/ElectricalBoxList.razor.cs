using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.ElectricalBox.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ElectricalBox.List
{
    public partial class ElectricalBoxList : TableTemplate<EditElectricalBox>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.ElectricalBoxs = await CommandQuery.GetAll();

            TableName = "Electrical Box";
       
          
        }
        public async Task<bool> ShowTableDialog(EditElectricalBox model)
        {

            var result = await DialogService.OpenAsync<ElectricalBoxDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
