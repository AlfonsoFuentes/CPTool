using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using CPTool.UIApp.AppPages.Taks;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOs
{
    public partial class MWOsList
    {
        [Inject]
        public IMWOService Service { get; set; }

        List<CommandMWO> Elements = new();
        CommandMWO SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandMWO model)
        {

            var result = await DialogService.OpenAsync<MWODialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        bool DisableEdit => SelectedItem.Id == 0;
        async Task<bool> Delete(CommandMWO toDelete)
        {
            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
        void GoToUserRequirmentPage()
        {
            NavigationManager.NavigateTo($"user-requirement/{SelectedItem.Id}");
        }
        void GoToPurchaseOrderList()
        {
            NavigationManager.NavigateTo($"purchase-orders/{SelectedItem.Id}");
        }
        void GoToUserSignalList()
        {
            NavigationManager.NavigateTo($"signals/{SelectedItem.Id}");
        }
        void GoToMWOItemList()
        {
            NavigationManager.NavigateTo($"mwo-items/{SelectedItem.Id}");
        }
        void GoToControlLoopList()
        {
            NavigationManager.NavigateTo($"control-loops/{SelectedItem.Id}");
        }
        async Task CreateTaskMWO()
        {
            CommandTaks editTaks = new CommandTaks();
            editTaks.MWO = SelectedItem;
            editTaks.TaksType = TaksType.Manual;
            var result = await ShowTaksDialog(editTaks);

        }
        public async Task<bool> ShowTaksDialog(CommandTaks model)
        {

            var result = await DialogService.OpenAsync<TaksDialog>(model.Id == 0 ? $"Add new Task to {SelectedItem.Name}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;
           
        }


    }
}
