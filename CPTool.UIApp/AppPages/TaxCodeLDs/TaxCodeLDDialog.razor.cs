using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.TaxCodeLDs
{
    public partial class TaxCodeLDDialog
    {
        [Inject]
        public ITaxCodeLDService Service { get; set; }
        [Parameter]
        public CommandTaxCodeLD Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
