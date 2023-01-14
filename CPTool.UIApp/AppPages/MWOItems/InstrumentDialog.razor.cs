

using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class InstrumentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;
        async Task ChangeBrand(int brandid)
        {
            Model.Supplier = new();
            DialogParent.PreviousValues.BrandId = brandid;
            await DialogParent.VerifiyePrevious();
            DialogData.Suppliers=await DialogParent.Service.GetSupliersByBrand(brandid);
        }
        async Task ChangeSupplier(int supplierid)
        {

            DialogParent.PreviousValues.SupplierId = supplierid;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeOuterMaterial(int outermaterial)
        {

            DialogParent.PreviousValues.OuterMaterialId = outermaterial;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeOuterInnerMaterial(int innermaterialid)
        {

            DialogParent.PreviousValues.InnerMaterialId = innermaterialid;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeMeasuredVariable(int MeasuredVariable)
        {

            DialogParent.PreviousValues.MeasuredVariableId = MeasuredVariable;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeMeasuredVariableModifier(int MeasuredVariableModifier)
        {

            DialogParent.PreviousValues.MeasuredVariableModifierId = MeasuredVariableModifier;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeReadout(int Readout)
        {

            DialogParent.PreviousValues.ReadoutId = Readout;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeDeviceFunction(int DeviceFunction)
        {

            DialogParent.PreviousValues.DeviceFunctionId = DeviceFunction;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeDeviceFunctionModifier(int DeviceFunctionModifier)
        {

            DialogParent.PreviousValues.DeviceFunctionModifierId = DeviceFunctionModifier;
            await DialogParent.VerifiyePrevious();

        }
    }
}
