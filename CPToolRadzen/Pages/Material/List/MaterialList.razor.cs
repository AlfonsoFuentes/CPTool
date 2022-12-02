using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;

using CPToolRadzen.Pages.Material.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Material.List
{
    public partial class MaterialList : BaseTableTemplate<EditMaterial>
    {

        public override List<EditMaterial> Elements => RadzenTables.Materials;



        protected override void OnInitialized()
        {
            TableName = "Material";
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditMaterial model)
        {

            var result = await DialogService.OpenAsync<MaterialDialog>(model.Id == 0 ? $"Add new Material" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
