using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.UnitsSystem
{
    public class UnitLess : Amount
    {
        public UnitLess() : this(0)
        {

        }
        public UnitLess(double dvalue) : base(dvalue, Unit.None)
        {

        }

    }
    public class Length : Amount
    {
        public Length() : this(0)
        {

        }
        public Length(double dvalue) : base(dvalue, LengthUnits.Meter)
        {

        }
        public Length(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }
    public class Area : Amount
    {
        public Area() : this(0)
        {

        }
        public Area(double dvalue) : base(dvalue, SurfaceUnits.Meter2)
        {

        }


    }
    public class Volume : Amount
    {
        public Volume() : this(0)
        {

        }
        public Volume(double dvalue) : base(dvalue, VolumeUnits.Meter3)
        {

        }
        public Volume(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }
    public class Time : Amount
    {
        public Time() : this(0)
        {

        }
        public Time(double dvalue) : base(dvalue, TimeUnits.Second)
        {

        }
        public Time(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }
    public class Velocity : Amount
    {
        public Velocity() : this(0)
        {

        }
        public Velocity(double dvalue) : base(dvalue, VelocityUnits.MeterPerSecond)
        {

        }
        public Velocity(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Mass : Amount
    {
        public Mass() : this(0)
        {

        }
        public Mass(double dvalue) : base(dvalue, MassUnits.KiloGram)
        {

        }
        public Mass(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Force : Amount
    {
        public Force() : this(0)
        {

        }
        public Force(double dvalue) : base(dvalue, ForceUnits.Newton)
        {

        }
        public Force(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }

    public class Electric : Amount
    {
        public Electric() : this(0)
        {

        }
        public Electric(double dvalue) : base(dvalue, ElectricUnits.Ampere)
        {

        }
        public Electric(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Power : Amount
    {
        public Power() : this(0)
        {

        }
        public Power(double dvalue) : base(dvalue, PowerUnits.KiloWatt)
        {

        }
        public Power(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Energy : Amount
    {
        public Energy() : this(0)
        {

        }
        public Energy(double dvalue) : base(dvalue, EnergyUnits.KiloCalorie)
        {

        }
        public Energy(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Temperature : Amount
    {
        public Temperature() : this(0)
        {

        }
        public Temperature(double dvalue) : base(dvalue, TemperatureUnits.DegreeCelcius)
        {

        }
        public Temperature(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Pressure : Amount
    {
        public Pressure() : this(0)
        {

        }
        public static Amount manometric;

        public Pressure(double dvalue) : base(dvalue, PressureUnits.Bar)
        {

        }
        public Pressure(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class MotorVelocity : Amount
    {
        public MotorVelocity() : this(0)
        {

        }
        public MotorVelocity(double dvalue) : base(dvalue, MotorVelocityUnits.Hertz)
        {

        }
        public MotorVelocity(double dvalue, Unit u) : base(dvalue, u)
        {

        }
        public Amount NominalRPM { get; set; }
        public Amount CurrentRPM { get; set; }
        public Amount SpeedVelocity { get; set; }

        public MotorVelocity(MotorVelocity moto) : base(0, MotorVelocityUnits.Hertz)
        {
            NominalRPM = new Amount(moto.NominalRPM);
            CurrentRPM = new Amount(moto.CurrentRPM);
            SpeedVelocity = new Amount(moto.SpeedVelocity);
        }
        void CalculateRPM()
        {
            CurrentRPM.SetValue(SpeedVelocity.Value * NominalRPM.Value / 100, MotorVelocityUnits.RPM);
        }
    }
    public class Percentage : Amount
    {
        public Percentage() : this(0)
        {

        }
        public Percentage(double dvalue) : base(dvalue, PercentageUnits.Percentage)
        {

        }
        public Percentage(double dvalue, Unit u) : base(dvalue, u)
        {

        }


        public override void SetValue(double dvalue, Unit unit)
        {
            if (beforeValue != dvalue)
            {
                if (dvalue < 0) dvalue = 0;
                if (dvalue > 100) dvalue = 100;

                this.dvalue = dvalue;
                this.unit = unit;
                if (OnValueChanged != null) OnValueChanged();

                beforeValue = dvalue;
            }
        }

    }
    public class AmountOfSubstance : Amount
    {
        public AmountOfSubstance() : this(0)
        {

        }
        public AmountOfSubstance(double dvalue) : base(dvalue, AmountOfSubstanceUnits.Mole)
        {

        }
        public AmountOfSubstance(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }

    public class HeatTransferCoefficient : Amount
    {
        public HeatTransferCoefficient() : this(0)
        {

        }
        public HeatTransferCoefficient(double dvalue) : base(dvalue, HeatTransferCoefficientUnits.BTU_hr_ft2_F)
        {

        }
        public HeatTransferCoefficient(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }
    public class MassDensity : Amount
    {
        public MassDensity() : this(0)
        {

        }
        public MassDensity(double dvalue) : base(dvalue, MassDensityUnits.Kg_m3)
        {

        }
        public MassDensity(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class DropPressure : Amount
    {
        public DropPressure() : this(0)
        {

        }
        public DropPressure(double dvalue) : base(dvalue, DropPressureUnits.psi)
        {

        }
        public DropPressure(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class DropPressureLength : Amount
    {
        public DropPressureLength() : this(0)
        {

        }
        public DropPressureLength(double dvalue) : base(dvalue, DropPressureLengthUnits.psi_100ft)
        {

        }
        public DropPressureLength(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class ThermalConductivity : Amount
    {
        public ThermalConductivity() : this(0)
        {

        }
        public ThermalConductivity(double dvalue) : base(dvalue, ThermalConductivityUnits.W_m_K)
        {

        }
        public ThermalConductivity(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class VolumeEnergy : Amount
    {
        public VolumeEnergy() : this(0)
        {

        }
        public VolumeEnergy(double dvalue) : base(dvalue, VolumeEnergyUnits.Kcal_m3)
        {

        }
        public VolumeEnergy(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class MassEnergy : Amount
    {
        public MassEnergy() : this(0)
        {

        }
        public MassEnergy(double dvalue) : base(dvalue, MassEnergyUnits.Kcal_Kg)
        {

        }
        public MassEnergy(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class MassEntropy : Amount
    {
        public MassEntropy() : this(0)
        {

        }
        public MassEntropy(double dvalue) : base(dvalue, MassEntropyUnits.Kcal_Kg_C)
        {

        }
        public MassEntropy(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class MassFlow : Amount
    {
        public MassFlow() : this(0)
        {

        }
        public MassFlow(double dvalue) : base(dvalue, MassFlowUnits.Kg_hr)
        {

        }
        public MassFlow(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class HeatSurfaceFlow : Amount
    {
        public HeatSurfaceFlow() : this(0)
        {

        }
        public HeatSurfaceFlow(double dvalue) : base(dvalue, HeatSurfaceFlowUnits.BTU_hr_ft2)
        {

        }
        public HeatSurfaceFlow(double dvalue, Unit u) : base(dvalue, u)
        {

        }


    }
    public class VolumetricFlow : Amount
    {
        public VolumetricFlow() : this(0)
        {

        }
        public VolumetricFlow(double dvalue) : base(dvalue, VolumetricFlowUnits.m3_hr)
        {

        }
        public VolumetricFlow(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class EnergyFlow : Amount
    {
        public EnergyFlow() : this(0)
        {

        }
        public EnergyFlow(double dvalue) : base(dvalue, EnergyFlowUnits.Kcal_hr)
        {

        }
        public EnergyFlow(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }
    public class Viscosity : Amount
    {
        public Viscosity() : this(0)
        {

        }
        public Viscosity(double dvalue) : base(dvalue, ViscosityUnits.cPoise)
        {

        }
        public Viscosity(double dvalue, Unit u) : base(dvalue, u)
        {

        }

    }

}

