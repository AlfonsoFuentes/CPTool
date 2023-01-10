using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItems
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
            

            var result = await DialogService.OpenAsync<MWOItemDialog>(model.Id == 0 ? $"Add new Item" : $"Edit {model.Name}",
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
            DialogService.Close(false);
        }
    }
}
