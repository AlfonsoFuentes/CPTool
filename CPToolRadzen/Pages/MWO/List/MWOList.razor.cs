using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen.Blazor;
using Radzen;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Services;
using CPTool.Application.Features.MMOTypeFeatures;
using CPToolRadzen.Services;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPTool.Domain.Entities;
using CPToolRadzen.Pages.Taks.Dialog;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPToolRadzen.Pages.MWO.Dialog;

namespace CPToolRadzen.Pages.MWO.List
{
    public partial class MWOList : BaseTableTemplate<EditMWO>
    {
        public override List<EditMWO> Elements => RadzenTables.MWOs;

        void GoToUserRequirmentPage()
        {
            NavigationManager.NavigateTo($"user-requirement/{Selected.Id}");
        }
        void GoToPurchaseOrderList()
        {
            NavigationManager.NavigateTo($"purchase-order/{Selected.Id}");
        }
        void GoToUserSignalList()
        {
            NavigationManager.NavigateTo($"signals/{Selected.Id}");
        }
        void GoToMWOItemList()
        {
            NavigationManager.NavigateTo($"mwo-items/{Selected.Id}");
        }
        void GoToControlLoopList()
        {
            NavigationManager.NavigateTo($"control-loops/{Selected.Id}");
        }
        async Task CreateTaskMWO()
        {
            EditTaks editTaks = new EditTaks();
            editTaks.MWO = Selected;
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
