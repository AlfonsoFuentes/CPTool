using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPToolRadzen.Pages.EquipmentType.Dialog;
using DocumentFormat.OpenXml.Office2013.PowerPoint;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.EquipmentType.List
{
    public partial class EquipmentTypeSubList: TableTemplate<EditEquipmentTypeSub>
    {
      
        protected override void OnInitialized()
        {
           

            TableName = "Equipment sub type";

        }

       
       
        public async Task<bool> ShowDialogDetail(EditEquipmentTypeSub model)
        {
            if (model.Id == 0)
            {
              
                model.EquipmentType = await QueryEquipmentType.GetById(ParentId);


            }
            var result = await DialogService.OpenAsync<EquipmentTypeSubDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
