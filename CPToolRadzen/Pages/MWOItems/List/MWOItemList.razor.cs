

using CPTool.Application.Generic;
using CPToolRadzen.Pages.MWOItems.Dialog;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.MWOItems.List
{
    public partial class MWOItemList : TableTemplate<EditMWOItem>
    {


       
        EditMWO Parent = new();

        double SumBudget => RadzenTables.MWOItems.Count == 0 ? 0 : RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).Sum(y => y.BudgetPrize);
        double SumAssigned => RadzenTables.MWOItems.Count == 0 ? 0 : RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).Sum(y => y.Assigned);
        double SumActual => RadzenTables.MWOItems.Count == 0 ? 0 : RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).Sum(y => y.Actual);
        double SumCommitment => RadzenTables.MWOItems.Count == 0 ? 0 : RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).Sum(y => y.Commitment);
        double SumPending => RadzenTables.MWOItems.Count == 0 ? 0 : RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).Sum(y => y.Pending);
        protected override async Task OnInitializedAsync()
        {
            Parent = await QueryMWO.GetById(ParentId);
            RadzenTables.MWOItems = await CommandQuery.GetAll();
           
      
        }
        
        public async Task<bool> ShowTableDialog(EditMWOItem model)
        {
            if (model.Id == 0)
            {

                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<MWOItemDialog>(model.Id == 0 ? $"Add new Item" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
