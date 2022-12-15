using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CPToolRadzen.Pages.BrandSupplier.Dialog
{
    public partial class BrandDialog : DialogTemplate<EditBrandSupplier>
    {

       
        protected override async Task OnInitializedAsync()
        {
           
            FilteredList = await CommandQuery.GetAll();
            Model.Brand = await QueryBrand.GetById(Model.Brand.Id);
            RadzenTables.Brands = await QueryBrand.GetAll();
            RadzenTables.Brands=Model.Brand.Id==0? RadzenTables.Brands: RadzenTables.Brands.Where(x=>x.Id!=Model.Brand.Id).ToList();    
            RadzenTables.Suppliers = await QuerySupplier.GetAll();

        }




        async Task SaveBrand()
        {
            try
            {
                if (SaveDialog)
                {
                    await QueryBrand.AddUpdate(Model.Brand);
                    var result = await QueryBrandSupplier.AddUpdate(Model);

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
