


using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Domain.Entities;
using MudBlazor;
using static MudBlazor.Icons.Custom;

namespace CPTool.NewPages.Dialogs.BrandSupplier.List
{
    public partial class BrandSupplierList
    {
        [Inject]
        public IMediator mediator { get; set; }

        EditBrand SelectedBrand { get; set; } = new();
        EditSupplier SelectedSupplier { get; set; } = new();

        List<EditSupplier> Suppliers = new();
        List<EditBrand> Brands = new();
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
        async Task RowClickedMaster(EditBrand row)
        {
            GlobalTables.Brands = Brands = await mediator.Send(BrandList);
            await AsignBrand(row);

          
        }
        async Task RowClickedDetails(EditSupplier row)
        {
            GlobalTables.Suppliers = Suppliers = await mediator.Send(SupplierList);
            await AsignSupplier(row);


        }
        
        async Task AsignBrand(EditBrand brand)
        {
            if(brand.Id!=0)
            {
                GetByIdBrandQuery getbyd = new() { Id = brand.Id };

                SelectedBrand = await mediator.Send(getbyd);
                SelectedSupplier = new();
                Suppliers = SelectedBrand.BrandSuppliers.Select(x => x.Supplier).ToList();
            }
            else
            {
                SelectedBrand = new();
                
            }
           
        }
        async Task AsignSupplier(EditSupplier suplier)
        {
            if (suplier.Id != 0)
            {
                GetByIdSupplierQuery getbyd = new() { Id = suplier.Id };

                SelectedSupplier = await mediator.Send(getbyd);
                SelectedBrand = new();
                Brands = SelectedSupplier.BrandSuppliers.Select(x => x.Brand).ToList();
            }
            else
            {
                SelectedSupplier = new();
            }
        }



    }
}
