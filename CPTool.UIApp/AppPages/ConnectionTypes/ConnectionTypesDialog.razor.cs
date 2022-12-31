﻿using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.ConnectionTypes
{
    public partial class ConnectionTypesDialog
    {
        [Inject]
        public IConnectionTypeService Service { get; set; }
        [Parameter]
        public CommandConnectionType Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
