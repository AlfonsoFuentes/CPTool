using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CPToolRadzen.Pages.BrandSupplier.Dialog
{
    public partial class BrandDialog
    {
        [Inject]
        public ICommandQuery<EditBrand> CommandBrand { get; set; }

        [Inject]
        public ICommandQuery<EditBrandSupplier> CommandQuery { get; set; }

        protected List<EditBrand> FilteredList => ( Model.Brand.Id == 0) ? RadzenTables.Brands : RadzenTables.Brands.Where(x => x.Id != Model.Brand.Id).ToList();
        [Parameter]
        public EditBrandSupplier Model { get; set; } = new();

       
        protected bool errorVisible;


        [Parameter]
        public bool SaveDialog { get; set; } = true;


        protected async virtual Task FormSubmit()
        {
            try
            {
                if (SaveDialog)
                {
                    await CommandBrand.AddUpdate(Model.Brand);
                    var result = await CommandQuery.AddUpdate(Model);
                    if (result.Succeeded)
                    {
                        RadzenTables.BrandSuppliers = await CommandQuery.GetAll();
                    }
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

        protected void CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(false);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;


        protected async Task ReloadButtonClick(MouseEventArgs args)
        {
            CommandQuery.Reset();
            hasChanges = false;
            canEdit = true;


            Model = await CommandQuery.GetById(Model.Id);
        }
    }
}
