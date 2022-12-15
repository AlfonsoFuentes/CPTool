
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class MWOItemDialog : DialogTemplate<EditMWOItem>
    {

        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.PipeClasses = await QueryPipeClass.GetAll();
            RadzenTables.PipeDiameters = await QueryPipeDiameter.GetAll();
            RadzenTables.ConnectionTypes = await QueryConnectionType.GetAll();
            RadzenTables.Materials = await QueryMaterial.GetAll();
            RadzenTables.Gaskets = await QueryGasket.GetAll();
            RadzenTables.EquipmentTypes= await QueryEquipmentType.GetAll();
            RadzenTables.EquipmentTypeSubs= await QueryEquipmentTypeSub.GetAll();
            RadzenTables.Brands= await QueryBrand.GetAll();
            RadzenTables.Suppliers=await QuerySupplier.GetAll();
            RadzenTables.BrandSuppliers=await QueryBrandSupplier.GetAll();
            RadzenTables.Chapters = await QueryChapter.GetAll();
            RadzenTables.MeasuredVariables=await QueryMeasuredVariable.GetAll();
            RadzenTables.MeasuredVariableModifiers = await QueryMeasuredVariableModifier.GetAll();
            RadzenTables.Readouts = await QueryReadout.GetAll();
            RadzenTables.DeviceFunctions = await QueryDeviceFunction.GetAll();
            RadzenTables.DeviceFunctionModifiers = await QueryDeviceFunctionModifier.GetAll();
            RadzenTables.ProcessFluids = await QueryProcessFluid.GetAll();
        }


       public async Task UpdateModel()
        {
            Model = await CommandQuery.GetById(Model.Id);
            StateHasChanged();
        }
    }
}
