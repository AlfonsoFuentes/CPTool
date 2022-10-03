


using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
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

        public List<AddEditBrandCommand> ElementsBrand = new();
        public List<AddEditSupplierCommand> ElementsSupplier = new();


        protected override async Task OnInitializedAsync()
        {
            ElementsBrand = await mediator.Send(BrandListQuery);
            ElementsSupplier = await mediator.Send(SupplierListQuery);
        }

        void RowClickedMaster(AddEditBrandCommand row)
        {
            AsignBrand(row);


        }
        void RowClickedDetails(AddEditSupplierCommand row)
        {
            AsignSupplier(row);



        }
        void AsignBrand(AddEditBrandCommand brand)
        {
            SelectedBrand = brand;
            ElementsSupplier = SelectedBrand.BrandSuppliers.Select(x => x.SupplierCommand).ToList();
        }
        void AsignSupplier(AddEditSupplierCommand suplier)
        {
            SelectedSupplier = suplier;
            ElementsBrand = SelectedSupplier.BrandSuppliers.Select(x => x.BrandCommand).ToList();
        }
       
      
       
    }
}
