using CPTool.Application.Generic;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CPTool.ApplicationCQRSResponses;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CPTool.ApplicationCQRS.Responses;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class DialogTemplate<T>
        where T : CommandBase, new()
    {




        [Parameter]
        public T Model { get; set; } = new();
        [Parameter]
        public RenderFragment ChildContent { get; set; }


        protected bool errorVisible;

        [Parameter]
        public bool SaveDialog { get; set; } = true;
        [Parameter]
        public string SaveButtonName { get; set; } = "Save";
        [Parameter]
        public bool DisableButtonSave { get; set; } = false;
        [Parameter]
        public Func<Task<BaseResponse>> Save { get; set; }

        List<string> errors = new();
        protected virtual async Task FormSubmit()
        {
            var result = await Save.Invoke();
            if (result.Success)
            {
                DialogService.Close(result.Success);
            }
            else
            {
                errors = result.ValidationErrors;

                errorVisible = true;
            }
        }

        protected void CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(false);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;


        protected async Task ReloadButtonClick(MouseEventArgs args)
        {
           
            hasChanges = false;
            canEdit = true;


            await Task.CompletedTask;
        }
    }
}
