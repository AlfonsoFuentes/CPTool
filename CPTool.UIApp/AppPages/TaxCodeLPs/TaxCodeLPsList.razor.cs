using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;

using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.TaxCodeLPs
{
    public partial class TaxCodeLPsList
    {
        [Inject]
        public ITaxCodeLPService Service { get; set; }

        List<CommandTaxCodeLP> Elements = new();
        CommandTaxCodeLP SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandTaxCodeLP model)
        {

            var result = await DialogService.OpenAsync<TaxCodeLPDialog>(model.Id == 0 ? $"Add new Tax Code LP" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandTaxCodeLP toDelete)
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
            return await Service.GetFiletoExport(type);
        }
    }
}
