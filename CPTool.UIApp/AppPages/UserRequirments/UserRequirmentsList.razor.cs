using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.UserRequirments
{
    public partial class UserRequirmentsList
    {
        [Inject]
        public IUserRequirementService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandUserRequirement> Elements = new();
        CommandUserRequirement SelectedItem = new();
        [Parameter]
        public int MWOId { get; set; }
      
        CommandMWO Parent = new();
        
        public async Task UpdateTable()
        {
            Parent = await MWOService.GetById(MWOId);
            Elements = await Service.GetAll(MWOId);
            StateHasChanged();
        }
        async Task<bool> ShowTableDialog(CommandUserRequirement model)
        {
            if (model.Id == 0)
            {

                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<UserRequirmentsDialog>(model.Id == 0 ? $"Add new User Requirment to {model.MWOName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "600px", Height = "450px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll(MWOId);
               
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandUserRequirement toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll(MWOId);
               
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
    }
}
