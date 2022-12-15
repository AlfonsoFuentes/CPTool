using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Generic;

namespace CPToolRadzen.Templates
{
    public partial class DialogTemplate<T>
        where T : EditCommand, new() 
    {
        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }

       
        public List<T> FilteredList { get; set; } = new();
        [Parameter]
        public T Model { get; set; } = new();
        [Parameter]
        public RenderFragment ChildContent { get; set; }

      
        protected bool errorVisible;
      
        [Parameter]
        public bool SaveDialog { get; set; } = true;
        [Parameter]
        public  string SaveButtonName { get; set; } = "Save";
        [Parameter]
        public  bool DisableButtonSave { get; set; } = false;
        [Parameter]
        public EventCallback Save { get; set; }
        
        protected virtual async  Task FormSubmit()
        {
            try
            {
                if (Save.HasDelegate)  await Save.InvokeAsync();
                else if (SaveDialog)
                {
                    var result = await CommandQuery.AddUpdate(Model);

                    DialogService.Close(result.Succeeded);
                }
                else
                {
                    DialogService.Close(true);
                }
            }
            catch (Exception ex)
            {
                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
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
            CommandQuery.Reset();
            hasChanges = false;
            canEdit = true;


            Model = await CommandQuery.GetById(Model.Id);
        }
    }
}
