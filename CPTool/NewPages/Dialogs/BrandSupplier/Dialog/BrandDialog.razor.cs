

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures;

using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.Query.GetList;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.BrandSupplier.Dialog
{
    public partial class BrandDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditBrandSupplier Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        GetBrandSupplierListQuery brandsuplierlist = new();
        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {
              
                var resultbrand = await mediator.Send(Model.Brand);
                if(resultbrand.Succeeded)
                {
                   
                    var result = await mediator.Send(Model);
                    if(result.Succeeded)
                    {
                        GlobalTables.BrandSuppliers = await mediator.Send(brandsuplierlist);
                    }
                }
               

                MudDialog.Close(DialogResult.Ok(Model.Brand));
            }
        }

        void Cancel() => MudDialog.Cancel();
      
        private string ValidateBrandType(BrandType arg)
        {
            if (arg == BrandType.None)
                return "Must submit Brand or Service Type";


            return null;
        }
        private string ValidateBrandName(string arg)
        {
            if (arg == null)
                return "Must submit Brand or Service Type";
            if (arg == "")
                return "Must submit Brand or Service Type";
            if(Model.Brand.Id==0)
            {
                if (GlobalTables.Brands.Any(x => x.Name == arg))
                    return "Name already exist";
            }
            else
            {
               
                if (GlobalTables.Brands.Where(x => x.Id != Model.Brand.Id).Any(x => x.Name == arg))
                    return "Name already exist";
            }
            


            return null;
        }
    }
}
