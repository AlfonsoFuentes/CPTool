using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using CPTool.UIApp.AppPages.MWOItems;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class MWOItemsPreviousValues
    {

        [Inject]
        public IMWOItemPrevisousValuesService Service { get; set; }
        List<CommandMWOItem> Elements = new();
        CommandMWOItem SelectedItem = new();
        [Parameter]
        public MWOItemPreviousValues Parameters { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll(Parameters);

        }
        async Task<bool> ShowTableDialog(CommandMWOItem model)
        {
            

            var result = await DialogService.OpenAsync<MWOItemDialog>( $"Review data in {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                
               
            }
            return (bool)result;

        }
        void CloseDialog()
        {
            MWOItemCommandResponse response = new();
            response.ResponseObject = SelectedItem;
            response.Success = true;
            DialogService.Close(response);
         
        }
        protected void CancelButtonClick(MouseEventArgs args)
        {
            MWOItemCommandResponse response = new();
            response.Success = false;
            DialogService.Close(response);
        }
    }
}
