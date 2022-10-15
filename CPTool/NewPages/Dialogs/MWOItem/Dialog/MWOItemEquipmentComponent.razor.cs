using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemEquipmentComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditEquipmentItem Model => DialogParent.Model.EquipmentItem;

        [Inject]
        public IMediator mediator { get; set; }

        private string ValidateEquipmentType(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Equipment Type";
            if (!GlobalTables.EquipmentTypes.Any(x => x.Name == arg))
                return $"Equipment Type: {arg} is not in the list";
            return null;
        }
        private string ValidateEquipmentSubType(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!Model.EquipmentType.EquipmentTypeSubs.Any(x => x.Name == arg))
                return $"Equipment Sub Type: {arg} is not in the list";
            return null;
        }
        void BrandChanged(EditBrand brand)
        {

            if (brand.Id != Model.Brand.Id)
            {
                Model.Brand = brand;
                Model.Supplier = new();
                StateHasChanged();
            }
        }
        async Task UpdateEquipmentType()
        {
            if (Model.EquipmentType.Id!=0)
            {
                GetByIdEquipmentTypeQuery getbyid = new() {Id= Model.EquipmentType.Id }; 
                Model.EquipmentType = await mediator.Send(getbyid);
                StateHasChanged();
            }
           
        }
    }
}
        