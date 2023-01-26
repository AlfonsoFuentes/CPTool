using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.PropertySpecifications;

using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class PropertiesSpecsListNew
    {
        [CascadingParameter]
        protected MWOItemDialogNew DialogParent { get; set; }
        [Inject]
        public IPropertySpecificationService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }
        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        List<CommandPropertySpecification> Elements => Model.PropertySpecifications;
        CommandPropertySpecification SelectedItem = new();

        CommandMWOItem Model => DialogParent.Model;


      

        async Task<bool> ShowTableDialog(CommandPropertySpecification model)
        {
            if (model.Id == 0)
            {
               
                model.MWOItem = DialogParent.Model;
                if (model.MWOItem.Id == 0)
                {

                    model.MWOItem.PropertySpecifications.Add(model);
                }


            }

            var result = await DialogService.OpenAsync<PropertySpecificationDialog>(model.Id == 0 ? $"Add new PropertySpecification" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "800px", Height = "850px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                await DialogParent.UpdateModel();
                await table.RefresheTable();
                StateHasChanged();
            }
            return (bool)result;

        }

        async Task<bool> Delete(CommandPropertySpecification toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                await DialogParent.UpdateModel();

                await table.RefresheTable();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
    }
}
