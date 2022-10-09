using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemEquipmentComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected AddEditEquipmentItemCommand Model => DialogParent.Model.EquipmentItemCommand;

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
            if (!Model.EquipmentTypeCommand.EquipmentTypesSubCommand.Any(x => x.Name == arg))
                return $"Equipment Sub Type: {arg} is not in the list";
            return null;
        }
        void BrandChanged(AddEditBrandCommand brand)
        {

            if (brand.Id != Model.BrandCommand.Id)
            {
                Model.BrandCommand = brand;
                Model.SupplierCommand = new();
                StateHasChanged();
            }
        }
        async Task UpdateEquipmentType()
        {
            if (Model.EquipmentTypeCommand.Id!=0)
            {
                GetByIdEquipmentTypeQuery getbyid = new() { Id = Model.EquipmentTypeCommand.Id };
                Model.EquipmentTypeCommand = await mediator.Send(getbyid);
                StateHasChanged();
            }
           
        }
    }
}
        