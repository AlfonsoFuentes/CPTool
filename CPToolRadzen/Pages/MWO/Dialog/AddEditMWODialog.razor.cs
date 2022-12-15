
using CPToolRadzen.Templates;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Generic;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;

namespace CPToolRadzen.Pages.MWO.Dialog
{
    public partial class AddEditMWODialog:DialogTemplate<EditMWO>
    {

      
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            RadzenTables.MWOTypes = await QueryMWOType.GetAll();
        
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
      
    }
}
