﻿using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.DownPayments
{
    public partial class DownPaymentDialog
    {
        [Inject]
        public IDownPaymentsService Service { get; set; }
        [Parameter]
        public CommandDownPayment Model { get; set; } = new();

       
        protected override async Task OnInitializedAsync()
        {
          
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);

        }
    }
}
