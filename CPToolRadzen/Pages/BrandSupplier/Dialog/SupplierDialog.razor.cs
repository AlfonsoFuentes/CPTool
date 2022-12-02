using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPToolRadzen.Pages.BrandSupplier.Dialog
{
    public partial class SupplierDialog 
    {
        [Inject]
        public ICommandQuery<EditSupplier> CommandSupplier{ get; set; }

        [Inject]
        public ICommandQuery<EditBrandSupplier> CommandQuery { get; set; }

        protected List<EditSupplier> FilteredList => (Model.SupplierId == 0) ? RadzenTables.Suppliers : 
            RadzenTables.Suppliers.Where(x => x.Id != Model.Supplier.Id).ToList();
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
                    await CommandSupplier.AddUpdate(Model.Supplier);
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
