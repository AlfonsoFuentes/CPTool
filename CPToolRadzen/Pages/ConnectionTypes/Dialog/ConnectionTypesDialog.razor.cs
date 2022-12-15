﻿using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ConnectionTypes.Dialog
{
    public partial class ConnectionTypesDialog : DialogTemplate<EditConnectionType>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
