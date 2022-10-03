

using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures;

using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;

using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.BrandSupplier.Dialog
{
    public partial class BrandDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditBrandSupplierCommand Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        List<AddEditSupplierCommand> Suppliers = new();
        List<AddEditBrandCommand> Brands = new();
        GetBrandListQuery BrandList = new();
        GetSupplierListQuery SupplierList = new();

        protected override async Task OnInitializedAsync()
        {
            Suppliers = await mediator.Send(SupplierList);
            Brands = await mediator.Send(BrandList);
        }
        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {
                Model.InletBy = InletBy.Brand;
                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model.BrandCommand));
            }
        }

        void Cancel() => MudDialog.Cancel();
        void SelectionSupplier(int id)
        {
            Model.SupplierCommand = Suppliers.FirstOrDefault(x => x.Id == id);
        }
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
            if(Model.BrandCommand.Id==0)
            {
                if (Brands.Any(x => x.Name == arg))
                    return "Name already exist";
            }
            else
            {
                if (Brands.Where(x => x.Id != Model.BrandCommand.Id).Any(x => x.Name == arg))
                    return "Name already exist";
            }
            


            return null;
        }
    }
}
