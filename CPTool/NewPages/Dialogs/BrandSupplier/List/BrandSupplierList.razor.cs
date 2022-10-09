


using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Domain.Entities;
using MudBlazor;

namespace CPTool.NewPages.Dialogs.BrandSupplier.List
{
    public partial class BrandSupplierList
    {
        [Inject]
        public IMediator mediator { get; set; }

        GetBrandListQuery BrandListQuery = new();
        GetSupplierListQuery SupplierListQuery = new();

        AddEditBrandCommand SelectedBrand { get; set; } = new();
        AddEditSupplierCommand SelectedSupplier { get; set; } = new();

        List<AddEditSupplierCommand> Suppliers = new();
        List<AddEditBrandCommand> Brands = new();
        GetBrandListQuery BrandList = new();
        GetSupplierListQuery SupplierList = new();


        protected override async Task OnInitializedAsync()
        {
            Suppliers = await mediator.Send(SupplierList);
            Brands = await mediator.Send(BrandList);
        }
        async Task ViewMasterList()
        {
            Suppliers = await mediator.Send(SupplierList);
            Brands = await mediator.Send(BrandList);
        }
        async Task RowClickedMaster(AddEditBrandCommand row)
        {
            await AsignBrand(row);

            GlobalTables.Brands = await mediator.Send(BrandList);
        }
        async Task RowClickedDetails(AddEditSupplierCommand row)
        {
            await AsignSupplier(row);

            GlobalTables.Suppliers = await mediator.Send(SupplierList);

        }
        async Task AsignBrand(AddEditBrandCommand brand)
        {

            GetByIdBrandQuery getbyd = new() { Id = brand.Id };

            SelectedBrand = await mediator.Send(getbyd);
            SelectedSupplier = new();
            Suppliers = SelectedBrand.BrandSuppliersCommand.Select(x => x.SupplierCommand).ToList();
        }
        async Task AsignSupplier(AddEditSupplierCommand suplier)
        {
            GetByIdSupplierQuery getbyd = new() { Id = suplier.Id };

            SelectedSupplier = await mediator.Send(getbyd);
            SelectedBrand = new();
            Brands = SelectedSupplier.BrandSuppliersCommand.Select(x => x.BrandCommand).ToList();
        }



    }
}
