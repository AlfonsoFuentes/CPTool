using Autofac.Core;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.BrandSupplier
{
    public partial class BrandSupplierList
    {
        [Inject]
        public IBrandSupplierService Service { get; set; }
        CommandBrand SelectedItemBrand = new();
        CommandSupplier SelectedItemSupplier = new();
        List<CommandBrand> _ElementsBrand = new();
        List<CommandSupplier> _ElementsSupplier = new();
        List<CommandBrandSupplier> ElementsBrandSupplier = new();
        List<CommandBrand> ElementsBrand
        {
            get
            {
                if (SelectedItemSupplier.Id == 0)
                    return _ElementsBrand;

                return ElementsBrandSupplier.Where(x => x.SupplierId == SelectedItemSupplier.Id).Select(x => x.Brand).ToList();
            }
           
        }

        List<CommandSupplier> ElementsSupplier
        {
            get
            {
                if (SelectedItemBrand.Id == 0)
                    return _ElementsSupplier;

                return ElementsBrandSupplier.Where(x => x.BrandId == SelectedItemBrand.Id).Select(x => x.Supplier).ToList();
            }
           
        }
        protected override async Task OnInitializedAsync()
        {
            _ElementsBrand = await Service.GetAllBrand();
            _ElementsSupplier = await Service.GetAllSupplier();
            ElementsBrandSupplier = await Service.GetAllBrandSupplier();
        }
        async Task<bool> ShowBrandDialog(CommandBrand modelBrand)
        {
            CommandBrandSupplier model = new() { Brand = modelBrand, Supplier = SelectedItemSupplier };

            var result = await DialogService.OpenAsync<BrandDialog>(modelBrand.Id == 0 ? $"Add new Brand" : $"Edit {modelBrand.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                _ElementsBrand = await Service.GetAllBrand();
                ElementsBrandSupplier = await Service.GetAllBrandSupplier();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> ShowSupplier(CommandSupplier modelSupplier)
        {
            CommandBrandSupplier model = new() { Brand = SelectedItemBrand, Supplier = modelSupplier };
            var result = await DialogService.OpenAsync<SupplierDialog>(modelSupplier.Id == 0 ? $"Add new Supplier" : $"Edit {modelSupplier.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                _ElementsSupplier = await Service.GetAllSupplier();
                ElementsBrandSupplier = await Service.GetAllBrandSupplier();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> DeleteBrand(CommandBrand toDelete)
        {
     
            var result = await Service.DeleteBrand(toDelete.Id);
            if (result.Success)
            {
                _ElementsBrand = await Service.GetAllBrand();
                ElementsBrandSupplier = await Service.GetAllBrandSupplier();
                SelectedItemBrand = new();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<bool> DeleteSupplier(CommandSupplier toDelete)
        {
            var result = await Service.DeleteSupplier(toDelete.Id);
            if (result.Success)
            {
                _ElementsSupplier = await Service.GetAllSupplier();
                ElementsBrandSupplier = await Service.GetAllBrandSupplier();
                SelectedItemSupplier = new();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> ExportBrand(string type)
        {
            return await Service.GetFiletoExportBrand(type, ElementsBrand);
        }
        async Task<ExportBaseResponse> ExportSupplier(string type)
        {
            return await Service.GetFiletoExportSupplier(type, ElementsSupplier);
        }
    }
}
