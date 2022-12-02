using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.ElectricalBox.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ElectricalBox.List
{
    public partial class ElectricalBoxList : BaseTableTemplate<EditElectricalBox>
    {

        public override List<EditElectricalBox> Elements => RadzenTables.ElectricalBoxs;



        protected override void OnInitialized()
        {
            TableName = "Electrical Box";
       
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditElectricalBox model)
        {

            var result = await DialogService.OpenAsync<ElectricalBoxDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
