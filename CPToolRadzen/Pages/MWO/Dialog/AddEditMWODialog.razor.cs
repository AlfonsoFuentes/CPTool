
using CPToolRadzen.Templates;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Generic;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Features.MOTypeFeatures.CreateEdit;

namespace CPToolRadzen.Pages.MWO.Dialog
{
    public partial class AddEditMWODialog:DialogTemplate<EditMWO>
    {

        List<EditMWOType> MWOTypes = new();
        protected override async Task OnInitializedAsync()
        {
            MWOTypes = await QueryMWOType.GetAll();
            Model = await CommandQuery.GetById(Model.Id);
           
        
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
      
    }
}
