using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.TaxCodeLPs
{
    public partial class TaxCodeLPDialog
    {
        [Inject]
        public ITaxCodeLPService Service { get; set; }
        [Parameter]
        public CommandTaxCodeLP Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
