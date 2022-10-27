using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool2.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemProcessConditions
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Parameter]
        public EditProcessCondition ProcessCondition { get; set; }

        [Parameter]
        public EventCallback<EditProcessCondition> ProcessConditionChanged { get; set; }

        [Parameter]
        public EditProcessFluid ProcessFluid { get; set; }

        [Inject]
        public IMediator mediator { get; set; }
        [Parameter]
        public EventCallback<EditProcessFluid> ProcessFluidChanged { get; set; }

        async Task OnProcessFluidChanged(EditProcessFluid pro)
        {
            ProcessFluid = pro;
            await ProcessFluidChanged.InvokeAsync(ProcessFluid);
        }

        void OnChangeTemperaturePressure()
        {
            if (ProcessFluid == null) return;
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.Pressure = ProcessCondition.Pressure.Amount;
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.Temperature = ProcessCondition.Temperature.Amount;
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateProperties();

            ProcessCondition.Density.Amount.SetValue(
                ProcessFluid.PropertyPackage.PropertyPackageCalculator.Density.GetValue(ProcessCondition.Density.Amount.Unit),
                ProcessCondition.Density.Amount.Unit
                );
            ProcessCondition.SpecificCp.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.SpecificCp.GetValue(ProcessCondition.SpecificCp.Amount.Unit),
               ProcessCondition.SpecificCp.Amount.Unit
               );
            ProcessCondition.SpecificEnthalpy.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.SpecificEnthalpy.GetValue(ProcessCondition.SpecificEnthalpy.Amount.Unit),
               ProcessCondition.SpecificEnthalpy.Amount.Unit
               );
            ProcessCondition.Viscosity.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.Viscosity.GetValue(ProcessCondition.Viscosity.Amount.Unit),
               ProcessCondition.Viscosity.Amount.Unit
               );
            ProcessCondition.ThermalConductivity.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.ThermalConductivity.GetValue(ProcessCondition.ThermalConductivity.Amount.Unit),
               ProcessCondition.ThermalConductivity.Amount.Unit
               );




        }
        void OnChangeMassFlow()
        {
            if (ProcessFluid == null) return;
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.MassFlow.SetValue(ProcessCondition.MassFlow.Amount.Value,
                ProcessCondition.MassFlow.Amount.Unit);
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateVolumetricFlow();
            ProcessCondition.VolumetricFlow.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.VolumetricFlow.GetValue(ProcessCondition.VolumetricFlow.Amount.Unit),
               ProcessCondition.VolumetricFlow.Amount.Unit
               );
            ProcessCondition.EnthalpyFlow.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.EnthalpyFlow.GetValue(ProcessCondition.EnthalpyFlow.Amount.Unit),
               ProcessCondition.EnthalpyFlow.Amount.Unit
               );


        }
        void OnChangeVolumetricFlow()
        {
            if (ProcessFluid == null) return;
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.VolumetricFlow.SetValue(ProcessCondition.VolumetricFlow.Amount.Value,
                ProcessCondition.VolumetricFlow.Amount.Unit);
            ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateMassFlow();

            ProcessCondition.MassFlow.Amount.SetValue(
              ProcessFluid.PropertyPackage.PropertyPackageCalculator.MassFlow.GetValue(ProcessCondition.MassFlow.Amount.Unit),
              ProcessCondition.MassFlow.Amount.Unit
              );
            ProcessCondition.EnthalpyFlow.Amount.SetValue(
               ProcessFluid.PropertyPackage.PropertyPackageCalculator.EnthalpyFlow.GetValue(ProcessCondition.EnthalpyFlow.Amount.Unit),
               ProcessCondition.EnthalpyFlow.Amount.Unit
               );



        }
    }
}
