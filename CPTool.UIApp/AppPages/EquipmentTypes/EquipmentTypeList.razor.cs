using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;

using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.EquipmentTypes
{
    public partial class EquipmentTypeList
    {
        [Inject]
        public IEquipmentTypeService Service { get; set; }

        List<CommandEquipmentType> Elements = new();
        List<CommandEquipmentTypeSub> ElementsSub = new();
        CommandEquipmentType SelectedItem = new();
        CommandEquipmentTypeSub SelectedItemSub = new();

        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowEquipmentTypeDialog(CommandEquipmentType model)
        {

            var result = await DialogService.OpenAsync<EquipmentTypeDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> DeleteEquipmentType(CommandEquipmentType toDelete)
        {
         
            var result = await Service.DeleteEquipment(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                SelectedItem = new();
                SelectedItemSub = new();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> ExportEquipmentType(string type)
        {
            return await Service.GetFiletoExportEquipment(type);
        }

        async Task<bool> ShowEquipmentTypeSubDialog(CommandEquipmentTypeSub model)
        {
            if (SelectedItem == null) return false;
            if(model.Id==0)
            {
                model.EquipmentType = SelectedItem;
            }
            var result = await DialogService.OpenAsync<EquipmentTypeSubDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                SelectedItem = Elements.FirstOrDefault(x => x.Id == SelectedItem.Id);
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> DeleteEquipmentTypeSub(CommandEquipmentTypeSub toDelete)
        {
            var result = await Service.DeleteEquipmentSub(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                SelectedItemSub = new();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> ExportEquipmentTypeSub(string type)
        {
            return await Service.GetFiletoExportEquipmentSub(type);
        }
        async Task OnChangeEquipmenType(int equipmentid)
        {
            ElementsSub= await Service.GetByEquipmentSubByEquipmenType(equipmentid);    
        }
    }
}
