using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.UnitaryPrizes
{
    public partial class UnitaryPrizesDialog
    {
        [Inject]
        public IUnitaryBasePrizeService Service { get; set; }
        [Parameter]
        public CommandUnitaryBasePrize Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
