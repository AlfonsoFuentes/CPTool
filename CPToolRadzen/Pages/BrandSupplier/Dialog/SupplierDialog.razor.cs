using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Generic;

namespace CPToolRadzen.Pages.BrandSupplier.Dialog
{
    public partial class SupplierDialog : DialogTemplate<EditBrandSupplier>
    {






        protected override async Task OnInitializedAsync()
        {

            FilteredList = await CommandQuery.GetAll();

            RadzenTables.Brands = await QueryBrand.GetAll();
            Model.Supplier = await QuerySupplier.GetById(Model.Supplier.Id);
            RadzenTables.Suppliers = await QuerySupplier.GetAll();
            RadzenTables.Suppliers = Model.Supplier.Id == 0 ? RadzenTables.Suppliers : RadzenTables.Suppliers.Where(x => x.Id != Model.Supplier.Id).ToList();
            RadzenTables.TaxCodeLDs=await QueryTaxCodeLD.GetAll();
            RadzenTables.TaxCodeLPs = await QueryTaxCodeLP.GetAll();
        }

       


        async  Task SaveSupplier()
        {
            try
            {
                if (SaveDialog)
                {
                    await QuerySupplier.AddUpdate(Model.Supplier);
                    var result = await CommandQuery.AddUpdate(Model);
                    

                    DialogService.Close(result.Succeeded);
                }
                else
                {
                    DialogService.Close(true);
                }
            }
            catch (Exception ex)
            {
                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
                errorVisible = true;
            }
        }

      
    }
}
