using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPTool.Domain.Entities;
using CPToolRadzen.Pages.BrandSupplier.Dialog;
using CPToolRadzen.Pages.MWO.Dialog;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.BrandSupplier.List
{
    public partial class BrandSupplierList
    {


        EditBrand SelectedBrand = new();
        EditSupplier SelectedSupplier = new();

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.Brands = await QueryBrand.GetAll();
            RadzenTables.Suppliers = await QuerySupplier.GetAll();
            RadzenTables.BrandSuppliers=await QueryBrandSupplier.GetAll();
        }
       

        List<EditBrand> GetBrands()
        {
            return SelectedSupplier.Id == 0 ? RadzenTables.Brands :
              RadzenTables.BrandSuppliers.Where(x => x.SupplierId == SelectedSupplier.Id).Select(x => x.Brand).ToList();

        }
        List<EditSupplier> GetSupplier() => SelectedBrand.Id == 0 ? RadzenTables.Suppliers :
            RadzenTables.BrandSuppliers.Where(x => x.BrandId == SelectedBrand.Id).Select(x => x.Supplier).ToList();

        public async Task<bool> ShowBrandDialog(EditBrandSupplier model)
        {
          

            var result = await DialogService.OpenAsync<BrandDialog>(model.Id == 0 ? $"Add new Brand" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            return (bool)result;

        }
        public async Task<bool> ShowSupplierDialog(EditBrandSupplier model)
        {

            var result = await DialogService.OpenAsync<SupplierDialog>(model.Id == 0 ? $"Add new Supplier" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            return (bool)result;

        }
        public async Task<bool> OnAddBrand(EditBrand brand)
        {
            EditBrandSupplier model = new();
            model.SetOriginalId(brand, SelectedSupplier);
            return await ShowBrandDialog(model);
        }
        public async Task<bool> OnEditBrand(EditBrand brand)
        {
            EditBrandSupplier model = new();

            model.SetOriginalId(brand, SelectedSupplier);
            return await ShowBrandDialog(model);
        }
        public async Task<bool> OnAddSupplier(EditSupplier supplier)
        {
            EditBrandSupplier model = new();
            model.SetOriginalId(SelectedBrand, supplier);
            return await ShowSupplierDialog(model);
        }
        public async Task<bool> OnEditSupplier(EditSupplier supplier)
        {
            EditBrandSupplier model = new();

            model.SetOriginalId(SelectedBrand, supplier);
            return await ShowSupplierDialog(model);
        }
    }
}
