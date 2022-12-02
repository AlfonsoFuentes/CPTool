using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPToolRadzen.Pages.EquipmentType.Dialog;
using CPToolRadzen.Pages.Gaskets.Dialog;
using CPToolRadzen.Pages.Material.Dialog;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class EquipmentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditEquipmentItem Model => DialogParent.Model.EquipmentItem;

        public async Task<bool> ShowEquipmentDialog(EditEquipmentType model)
        {

            var result = await DialogService.OpenAsync<EquipmentTypeDialog>(model.Id == 0 ? $"Add new Equipment Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        public async Task<bool> ShowEquipmentSubDialog(EditEquipmentTypeSub model)
        {
            if (model.Id == 0)
            {
                model.EquipmentType = Model.eEquipmentType;


            }
            var result = await DialogService.OpenAsync<EquipmentTypeSubDialog>(model.Id == 0 ? $"Add new Sub Type Equipment" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        async Task<bool> ShowGasketDialog(EditGasket model)
        {

            var result = await DialogService.OpenAsync<GasketsDialog>(model.Id == 0 ? $"Add new Gasket" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        public async Task<bool> ShowMaterialDialog(EditMaterial model)
        {

            var result = await DialogService.OpenAsync<MaterialDialog>(model.Id == 0 ? $"Add new Material" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        void ChangeBrand()
        {
            Model.eSupplier = new();
        }
        void ChangeEquipmentType()
        {
            Model.eEquipmentTypeSub = new();
        }
    }
}
