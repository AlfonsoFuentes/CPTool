using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.EquipmentType.Dialog;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CPToolRadzen.Pages.EquipmentType.List
{
    public partial class EquipmentTypeList : BaseTableTemplate<EditEquipmentType>
    {
        EditEquipmentTypeSub SelectedDetail = new();
        public override List<EditEquipmentType> Elements => RadzenTables.EquipmentTypes;

        List<EditEquipmentTypeSub> ElementsDetails=> Selected.Id==0?new(): RadzenTables.EquipmentTypeSubs.Where(x=>x.EquipmentTypeId==Selected.Id).ToList();    
        protected override void OnInitialized()
        {
            TableName = "Equipment Type";
            base.OnInitialized();
        }
        string TableNameDetails = "Equipment Type Sub";
        public async Task<bool> ShowDialog(EditEquipmentType model)
        {

            var result = await DialogService.OpenAsync<EquipmentTypeDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        public async Task<bool> ShowDialogDetail(EditEquipmentTypeSub model)
        {
            if (model.Id == 0)
            {
                model.EquipmentType = Selected;

               
            }
            var result = await DialogService.OpenAsync<EquipmentTypeSubDialog>(model.Id == 0 ? $"Add new {TableNameDetails}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
      
    }
}
