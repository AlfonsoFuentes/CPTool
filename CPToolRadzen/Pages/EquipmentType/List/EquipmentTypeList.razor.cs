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
    public partial class EquipmentTypeList : TableTemplate<EditEquipmentType>
    {
        protected override async Task OnInitializedAsync()
        {
            RadzenTables.EquipmentTypes = await QueryEquipmentType.GetAll();
            RadzenTables.EquipmentTypeSubs = await QueryEquipmentTypeSub.GetAll();


            TableName = "Equipment Type";
           
        }
       
        public async Task<bool> ShowTableDialog(EditEquipmentType model)
        {

            var result = await DialogService.OpenAsync<EquipmentTypeDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        
      
    }
}
