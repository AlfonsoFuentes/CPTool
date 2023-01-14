using Autofac.Core;

using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.UIApp.AppPages.MWOs;
using CPTool.UIApp.AppPages.PurchaseOrders;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class PurchaseOrderMWOItemDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
      
        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        async Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        {
            if(model.Id==0)
            {
                model.MWO = DialogParent.Model.MWO;
            }

            var result = await DialogService.OpenAsync<PurchaseOrderDialog>(model.Id == 0 ? $"Add new Purchase Order" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;

            if((bool)result)
            {
                await DialogParent.UpdateModel();
            }
           
            return (bool)result;

        }
    }
}
