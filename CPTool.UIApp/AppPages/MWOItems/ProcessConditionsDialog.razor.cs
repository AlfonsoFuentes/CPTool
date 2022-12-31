
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class ProcessConditionsDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;


      
        void ChangeProcessFluid()
        {

        }

        void OnChangeTemperaturePressure()
        {
            if (Model.ProcessFluid == null) return;
            if (Model.ProcessFluid.PropertyPackage == null) return;
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.Pressure = Model.ProcessCondition.Pressure.Amount;
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.Temperature = Model.ProcessCondition.Temperature.Amount;
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateProperties();

            Model.ProcessCondition.Density.Amount.SetValue(
                Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.Density.GetValue(Model.ProcessCondition.Density.Amount.Unit),
                Model.ProcessCondition.Density.Amount.Unit
                );
            Model.ProcessCondition.SpecificCp.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.SpecificCp.GetValue(Model.ProcessCondition.SpecificCp.Amount.Unit),
               Model.ProcessCondition.SpecificCp.Amount.Unit
               );
            Model.ProcessCondition.SpecificEnthalpy.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.SpecificEnthalpy.GetValue(Model.ProcessCondition.SpecificEnthalpy.Amount.Unit),
               Model.ProcessCondition.SpecificEnthalpy.Amount.Unit
               );
            Model.ProcessCondition.Viscosity.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.Viscosity.GetValue(Model.ProcessCondition.Viscosity.Amount.Unit),
               Model.ProcessCondition.Viscosity.Amount.Unit
               );
            Model.ProcessCondition.ThermalConductivity.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.ThermalConductivity.GetValue(Model.ProcessCondition.ThermalConductivity.Amount.Unit),
               Model.ProcessCondition.ThermalConductivity.Amount.Unit
               );




        }
        void OnChangeMassFlow()
        {
            if (Model.ProcessFluid == null) return;
            if (Model.ProcessFluid.PropertyPackage == null) return;
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.MassFlow.SetValue(Model.ProcessCondition.MassFlow.Amount.Value,
                Model.ProcessCondition.MassFlow.Amount.Unit);
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateVolumetricFlow();
            Model.ProcessCondition.VolumetricFlow.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.VolumetricFlow.GetValue(Model.ProcessCondition.VolumetricFlow.Amount.Unit),
               Model.ProcessCondition.VolumetricFlow.Amount.Unit
               );
            Model.ProcessCondition.EnthalpyFlow.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.EnthalpyFlow.GetValue(Model.ProcessCondition.EnthalpyFlow.Amount.Unit),
               Model.ProcessCondition.EnthalpyFlow.Amount.Unit
               );


        }
        void OnChangeVolumetricFlow()
        {
            if (Model.ProcessFluid == null) return;
            if (Model.ProcessFluid.PropertyPackage == null) return;
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.VolumetricFlow.SetValue(Model.ProcessCondition.VolumetricFlow.Amount.Value,
                Model.ProcessCondition.VolumetricFlow.Amount.Unit);
            Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.CalculateMassFlow();

            Model.ProcessCondition.MassFlow.Amount.SetValue(
              Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.MassFlow.GetValue(Model.ProcessCondition.MassFlow.Amount.Unit),
              Model.ProcessCondition.MassFlow.Amount.Unit
              );
            Model.ProcessCondition.EnthalpyFlow.Amount.SetValue(
               Model.ProcessFluid.PropertyPackage.PropertyPackageCalculator.EnthalpyFlow.GetValue(Model.ProcessCondition.EnthalpyFlow.Amount.Unit),
               Model.ProcessCondition.EnthalpyFlow.Amount.Unit
               );



        }

       
    }
}
