using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.BrandSupplier
{
    public partial class BrandDialog
    {
        [Inject]
        public IBrandSupplierService Service { get; set; }
        [Parameter]
        public CommandBrandSupplier Model { get; set; } = new();

        List<CommandSupplier> Suppliers = new();
        protected override async Task OnInitializedAsync()
        {
            Model.SetOriginalId();
            Suppliers = await Service.GetAllSupplier();
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdateBrand(Model);
        }
    }
}
