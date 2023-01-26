using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItemsNew.List
{
    public partial class MWOItemsListBudget
    {
        [CascadingParameter]
        public TabsMWOItems DialogParent { get; set; }
        [Inject]
        public IMWOItemService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandMWOItem> Elements => DialogParent.MWOItemListData.BudgetItems;
        CommandMWOItem SelectedItem = new();
       
        MWOItemDialogData DialogData = new();
        CommandMWO Parent => DialogParent.MWOItemListData.MWO;
        async Task<bool> ShowTableDialog(CommandMWOItem model)
        {
            if (model.Id == 0)
            {
                NavigationManager.NavigateTo($"MWOItemDialog/{Parent.Id}/true",true);
            }
            else
            {
                NavigationManager.NavigateTo($"MWOItemDialog/{Parent.Id}/{model.Id}/false", true);
            }
            return await Task.FromResult(true);
        }
        async Task<bool> ShowTableDialog2(CommandMWOItem model)
        {
            if (model.Id == 0)
            {

                model.MWO = Parent;
                model.BudgetItem = true;
            }

            var result = await DialogService.OpenAsync<MWOItemDialog>(model.Id == 0 ? $"Add new Item" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {

                DialogParent.MWOItemListData.BudgetItems = await Service.GetAll(Parent.Id);
                DialogParent.MWOItemListData.GetSummaryBudgetItem();
               
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandMWOItem toDelete)
        {
       
            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                DialogParent.MWOItemListData.BudgetItems = await Service.GetAll(Parent.Id);
                DialogParent.MWOItemListData.GetSummaryBudgetItem();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
        async Task SearchChanged(string searched)
        {
            DialogParent.MWOItemListData.BudgetItems = await Service.GetAllWithSearch(Parent.Id, searched);

        }
    }
}
