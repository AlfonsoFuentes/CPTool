using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Features.MOTypeFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPToolRadzen.Pages.MWOTypes.Dialog;


namespace CPToolRadzen.Pages.MWOTypes.List
{
    public partial class MWOTypesList : TableTemplate<EditMWOType>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.MWOTypes = await CommandQuery.GetAll();
        }
         public async Task<bool> ShowTableDialog(EditMWOType model)
        {

            var result = await DialogService.OpenAsync<AddEditMWOTypeDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }

    }
}

