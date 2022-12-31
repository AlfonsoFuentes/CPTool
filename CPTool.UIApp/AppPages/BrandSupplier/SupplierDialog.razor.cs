using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.BrandSupplier
{
    public partial class SupplierDialog
    {
        [Inject]
        public IBrandSupplierService Service { get; set; }
        [Parameter]
        public CommandBrandSupplier Model { get; set; } = new();

        SupplierDialogData DataDialog = new();
        protected override async Task OnInitializedAsync()
        {
            Model.SetOriginalId();
            DataDialog = await Service.GetSupplierDataDialog();
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdateSupplier(Model);
        }
    }
}
