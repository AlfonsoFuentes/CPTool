using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class MWOItemsList
    {
        [Inject]
        public IMWOItemService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandMWOItem> Elements = new();
        CommandMWOItem SelectedItem = new();
        [Parameter]
        public int MWOId { get; set; }
        MWOItemDialogData DialogData = new();
        CommandMWO Parent = new();
        protected override async Task OnInitializedAsync()
        {
            Parent = await MWOService.GetById(MWOId);
            Elements = await Service.GetAll(MWOId);
            DialogData.GetSummary(Elements);

        }

        async Task<bool> ShowTableDialog(CommandMWOItem model)
        {
            if (model.Id == 0)
            {

                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<MWOItemDialog>(model.Id == 0 ? $"Add new Item" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll(MWOId);
                DialogData.GetSummary(Elements);
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandMWOItem toDelete)
        {
       
            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll(MWOId);
                DialogData.GetSummary(Elements);
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
