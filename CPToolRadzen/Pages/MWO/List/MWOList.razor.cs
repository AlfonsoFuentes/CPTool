using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPToolRadzen.Pages.Taks.Dialog;

using CPToolRadzen.Pages.MWO.Dialog;
using CPTool.Domain.Enums;
using CPTool.Application.Generic;

namespace CPToolRadzen.Pages.MWO.List
{
    public partial class MWOList : TableTemplate<EditMWO>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.MWOs = await CommandQuery.GetAll();
         
        }
        void GoToUserRequirmentPage()
        {
            NavigationManager.NavigateTo($"user-requirement/{SelectedItem.Id}");
        }
        void GoToPurchaseOrderList()
        {
            NavigationManager.NavigateTo($"purchase-order/{SelectedItem.Id}");
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
            EditTaks editTaks = new EditTaks();
            editTaks.MWO = SelectedItem;
            editTaks.TaksType = TaksType.Manual;
            var result = await ShowTaksDialog(editTaks);
           
        }
        public async Task<bool> ShowTaksDialog(EditTaks model)
        {

            var result = await DialogService.OpenAsync<TaksDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        public async Task<bool> ShowMWODialog(EditMWO model)
        {

            var result = await DialogService.OpenAsync<AddEditMWODialog>(model.Id == 0 ? $"Add new MWO" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
