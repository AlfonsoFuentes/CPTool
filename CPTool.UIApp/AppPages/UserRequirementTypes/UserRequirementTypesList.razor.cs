using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.UnitaryPrizes;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.UserRequirementTypes
{
    public partial class UserRequirementTypesList
    {
        [Inject]
        public IUserRequirementTypeService Service { get; set; }

        List<CommandUserRequirementType> Elements = new();
        CommandUserRequirementType SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandUserRequirementType model)
        {

            var result = await DialogService.OpenAsync<UserRequirementTypesDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandUserRequirementType toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                SelectedItem = new();
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
    }
}
