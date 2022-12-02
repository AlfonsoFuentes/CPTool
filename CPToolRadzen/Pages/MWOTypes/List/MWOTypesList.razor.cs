using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPToolRadzen.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen.Blazor;
using Radzen;
using CPTool.Application.Features.MMOTypeFeatures.Query.GetList;

using CPTool.Application.Features.MMOTypeFeatures;
using CPToolRadzen.Pages.MWOTypes.Dialog;
using CPtool.ExtensionMethods;

namespace CPToolRadzen.Pages.MWOTypes.List
{
    public partial class MWOTypesList : BaseTableTemplate<EditMWOType>
    {
        EditMWOType MWOTypeSelected = new();

        public override List<EditMWOType> Elements => RadzenTables.MWOTypes;

        public async Task<bool> ShowDialog(EditMWOType model)
        {

            var result = await DialogService.OpenAsync<AddEditMWOTypeDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }

    }
}

