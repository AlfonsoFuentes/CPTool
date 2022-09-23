using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.UnitsSystem
{
    public static class SIUnitTypes
    {
        public static readonly UnitType Length = new UnitType("metre");
        public static readonly UnitType Mass = new UnitType("kilogram");
        public static readonly UnitType Time = new UnitType("second");
        public static readonly UnitType ElectricCurrent = new UnitType("ampere");
        public static readonly UnitType ThermodynamicTemperature = new UnitType("kelvin");
        public static readonly UnitType AmountOfSubstance = new UnitType("mole");
        public static readonly UnitType LuminousIntensity = new UnitType("candela");
        public static readonly UnitType Percentage = new UnitType("Percentage");
        public static readonly UnitType UnitLess = new UnitType("UnitLess");
    }
    [UnitDefinitionClass]
    public static class UnitLessUnits
    {
        public static readonly Unit None = new Unit("None", "xx", SIUnitTypes.UnitLess, "UnitLess");
    }

    [UnitDefinitionClass]
    public static class LengthUnits
    {
        public static readonly Unit Meter = new Unit("meter", "m", SIUnitTypes.Length, "Length");

        public static readonly Unit MilliMeter = new Unit("millimeter", "mm", 0.001 * Meter, "Length");
        public static readonly Unit CentiMeter = new Unit("centimeter", "cm", 0.01 * Meter, "Length");
        public static readonly Unit DeciMeter = new Unit("decimeter", "dm", 0.1 * Meter, "Length");
        public static readonly Unit DecaMeter = new Unit("decameter", "Dm", 10.0 * Meter, "Length");
        public static readonly Unit HectoMeter = new Unit("hectometer", "Hm", 100.0 * Meter, "Length");
        public static readonly Unit KiloMeter = new Unit("kilometer", "Km", 1000.0 * Meter, "Length");

        public static readonly Unit Inch = new Unit("inch", "in", 0.0254 * Meter, "Length");
        public static readonly Unit MicroInch = new Unit("microinch", "μ-in", 1e6 * Inch, "Length");
        public static readonly Unit Foot = new Unit("foot", "ft", 12.0 * Inch, "Length");
        public static readonly Unit Yard = new Unit("yard", "yd", 36.0 * Inch, "Length");
        public static readonly Unit Mile = new Unit("mile", "mi", 5280.0 * Foot, "Length");
        public static readonly Unit NauticalMile = new Unit("nautical mile", "nmi", 1852.0 * Meter, "Length");

        public static readonly Unit LightYear = new Unit("light-year", "ly", 9460730472580800.0 * Meter, "Length");
    }

    [UnitDefinitionClass]
    public static class SurfaceUnits
    {
        public static readonly Unit Meter2 = new Unit("meter²", "m²", LengthUnits.Meter.Power(2), "Surface");
        public static readonly Unit Are = new Unit("are", "are", 100.0 * Meter2, "Surface");
        public static readonly Unit HectAre = new Unit("hectare", "ha", 10000.0 * Meter2, "Surface");
        public static readonly Unit KiloMeter2 = new Unit("kilometer²", "Km²", LengthUnits.KiloMeter.Power(2), "Surface");

        public static readonly Unit decimeter2 = new Unit("decimeter²", "dm²", LengthUnits.DeciMeter.Power(2), "Surface");
        public static readonly Unit centimeter2 = new Unit("centimeter²", "cm²", LengthUnits.CentiMeter.Power(2), "Surface");
        public static readonly Unit milimeter2 = new Unit("milimeter²", "mm²", LengthUnits.MilliMeter.Power(2), "Surface");

        public static readonly Unit Mile2 = new Unit("Mile²", "mile²", LengthUnits.Mile.Power(2), "Surface");

        public static readonly Unit Acre = new Unit("Acre", "Acre", 4046.854 * Meter2, "Surface");
        public static readonly Unit Foot2 = new Unit("Foot²", "ft²", LengthUnits.Foot.Power(2), "Surface");
        public static readonly Unit inch2 = new Unit("inch²", "in²", LengthUnits.Inch.Power(2), "Surface");

    }

    [UnitDefinitionClass]
    public static class VolumeUnits
    {
        public static readonly Unit Meter3 = new Unit("meter³", "m³", LengthUnits.Meter.Power(3), "Volume");
        public static readonly Unit KMeter3 = new Unit("Kmeter³", "Km³", LengthUnits.KiloMeter.Power(3), "Volume");
        public static readonly Unit dMeter3 = new Unit("dmeter³", "dm³", LengthUnits.DeciMeter.Power(3), "Volume");
        public static readonly Unit cMeter3 = new Unit("cmeter³", "cm³", LengthUnits.CentiMeter.Power(3), "Volume");
        public static readonly Unit mMeter3 = new Unit("mmeter³", "mm³", LengthUnits.MilliMeter.Power(3), "Volume");
        public static readonly Unit Foot3 = new Unit("Foot³", "ft³", LengthUnits.Foot.Power(3), "Volume");
        public static readonly Unit inch3 = new Unit("inch³", "in³", LengthUnits.Inch.Power(3), "Volume");

        public static readonly Unit Liter = new Unit("liter", "L", 0.001 * Meter3, "Volume");
        public static readonly Unit MilliLiter = new Unit("milliliter", "mL", 0.001 * Liter, "Volume");
        public static readonly Unit CentiLiter = new Unit("centiliter", "cL", 0.01 * Liter, "Volume");
        public static readonly Unit DeciLiter = new Unit("deciliter", "dL", 0.1 * Liter, "Volume");
        public static readonly Unit HectoLiter = new Unit("Hectoliter", "dL", 0.1 * Meter3, "Volume");

        public static readonly Unit Galon = new Unit("Galon", "gal", Meter3 * 0.00378541, "Volume");
        public static readonly Unit Galon_1_4 = new Unit("1/4 galon", "1_4_gal", Galon / 4, "Volume");
        public static readonly Unit Barrel = new Unit("Barrel", "B", Meter3 * 0.15898724, "Volume");
    }

    [UnitDefinitionClass]
    public static class TimeUnits
    {
        public static readonly Unit Second = new Unit("second", "s", SIUnitTypes.Time, "Time");
        public static readonly Unit MicroSecond = new Unit("microsecond", "μs", 0.000001 * Second, "Time");
        public static readonly Unit MilliSecond = new Unit("millisecond", "ms", 0.001 * Second, "Time");
        public static readonly Unit Minute = new Unit("minute", "min", 60.0 * Second, "Time");
        public static readonly Unit Hour = new Unit("hour", "h", 3600.0 * Second, "Time");
        public static readonly Unit Day = new Unit("day", "d", 24.0 * Hour, "Time");
        public static readonly Unit Month = new Unit("Month", "mo", 24.0 * Day, "Time");

        public static readonly Unit Year = new Unit("Year", "Y", 12 * Month, "Time");
    }

    [UnitDefinitionClass]
    public static class VelocityUnits
    {
        public static readonly Unit MeterPerSecond = new Unit("meter/second", "m/s", LengthUnits.Meter / TimeUnits.Second, "Speed");
        public static readonly Unit MeterPerMinute = new Unit("meter/min", "m/min", LengthUnits.Meter / TimeUnits.Minute, "Speed");
        public static readonly Unit MeterPerHour = new Unit("meter/hour", "m/hr", LengthUnits.Meter / TimeUnits.Hour, "Speed");

        public static readonly Unit KilometerPerSecond = new Unit("kilometer/second", "km/s", LengthUnits.KiloMeter / TimeUnits.Second, "Speed");
        public static readonly Unit KilometerPerMinute = new Unit("kilometer/min", "km/min", LengthUnits.KiloMeter / TimeUnits.Minute, "Speed");
        public static readonly Unit KilometerPerHour = new Unit("kilometer/hour", "km/h", LengthUnits.KiloMeter / TimeUnits.Hour, "Speed");


        public static readonly Unit MilePerHour = new Unit("mile/hour", "mi/h", LengthUnits.Mile / TimeUnits.Hour, "Speed");
        public static readonly Unit FeetPerSecond = new Unit("Feet/Second", "ft/s", LengthUnits.Foot / TimeUnits.Second, "Speed");
        public static readonly Unit FeetPerMinute = new Unit("Feet/Minute", "ft/min", LengthUnits.Foot / TimeUnits.Minute, "Speed");
        public static readonly Unit FeetPerHour = new Unit("Feet/Hour", "ft/hr", LengthUnits.Foot / TimeUnits.Hour, "Speed");

        public static readonly Unit Knot = new Unit("knot", "kn", 1.852 * VelocityUnits.KilometerPerHour, "Speed");
    }

    [UnitDefinitionClass]
    public static class MassUnits
    {
        public static readonly Unit KiloGram = new Unit("kilogram", "Kg", SIUnitTypes.Mass, "Mass");

        public static readonly Unit Gram = new Unit("gram", "g", 0.001 * KiloGram, "Mass");
        public static readonly Unit MilliGram = new Unit("milligram", "mg", 0.001 * Gram, "Mass");
        public static readonly Unit Ton = new Unit("ton", "ton", 1000.0 * KiloGram, "Mass");

        public static readonly Unit Pound = new Unit("Pound", "lib", KiloGram / 2.2, "Mass");
        public static readonly Unit Onze = new Unit("Onze", "Oz", KiloGram / 35.27394095, "Mass");
    }

    [UnitDefinitionClass]
    public static class ForceUnits
    {
        public static readonly Unit Newton = new Unit("newton", "N",
            LengthUnits.Meter * MassUnits.KiloGram * TimeUnits.Second.Power(-2), "Force");
    }

    [UnitDefinitionClass]
    public static class ElectricUnits
    {
        public static readonly Unit Ampere = new Unit("ampere", "amp", SIUnitTypes.ElectricCurrent, "Electric");
        public static readonly Unit Coulomb = new Unit("coulomb", "C", TimeUnits.Second * Ampere, "Electric");
        public static readonly Unit Volt = new Unit("volt", "V", PowerUnits.Watt / Ampere, "Electric");
        public static readonly Unit Ohm = new Unit("ohm", "Ω", Volt / Ampere, "Electric");
        public static readonly Unit Farad = new Unit("farad", "F", Coulomb / Volt, "Electric");
    }
    [UnitDefinitionClass]
    public static class PowerUnits
    {
        public static readonly Unit Watt = new Unit("watt", "W", EnergyUnits.Joule / TimeUnits.Second, "Power");
        public static readonly Unit KiloWatt = new Unit("kilowatt", "kW", 1000.0 * Watt, "Power");
        public static readonly Unit MegaWatt = new Unit("megawatt", "MW", 1000000.0 * Watt, "Power");
        public static readonly Unit WattSecond = new Unit("watt-second", "Wsec", Watt * TimeUnits.Second, "Power");
        public static readonly Unit WattHour = new Unit("watt-hour", "Wh", Watt * TimeUnits.Hour, "Power");
        public static readonly Unit KiloWattHour = new Unit("kilowatt-hour", "kWh", 1000.0 * WattHour, "Power");
        public static readonly Unit HorsePower = new Unit("horsepower", "hp", 0.73549875 * KiloWatt, "Power");
    }
    [UnitDefinitionClass]
    public static class EnergyUnits
    {
        public static readonly Unit Joule = new Unit("joule", "J",
            LengthUnits.Meter.Power(2) * MassUnits.KiloGram * TimeUnits.Second.Power(-2), "Energy");
        public static readonly Unit KiloJoule = new Unit("kilojoule", "kJ", 1000.0 * Joule, "Energy");
        public static readonly Unit MegaJoule = new Unit("megajoule", "MJ", 1000000.0 * Joule, "Energy");
        public static readonly Unit GigaJoule = new Unit("gigajoule", "GJ", 1000000000.0 * Joule, "Energy");


        public static readonly Unit Calorie = new Unit("calorie", "cal", 4.1868 * Joule, "Energy");
        public static readonly Unit KiloCalorie = new Unit("kilocalorie", "kcal", 1000.0 * Calorie, "Energy");



        public static readonly Unit BTU = new Unit("BTU", "BTU", 1055.0559 * Joule, "Energy");
        public static readonly Unit foot_lb = new Unit("Foot-pound", "ft-pound", 1.3558 * Joule, "Energy");
    }

    [UnitDefinitionClass, UnitConversionClass]
    public static class TemperatureUnits
    {
        public static readonly Unit Kelvin = new Unit("Kelvin", "K", SIUnitTypes.ThermodynamicTemperature, "Temperature");
        public static readonly Unit DegreeCelcius = new Unit("degree celcius", "°C", new UnitType("celcius temperature"), "Temperature");
        public static readonly Unit DegreeFahrenheit = new Unit("degree fahrenheit", "°F", new UnitType("fahrenheit temperature"), "Temperature");

        #region Conversion functions

        public static void RegisterConversions()
        {
            // Register conversion functions:

            // Convert Celcius to Fahrenheit:
            UnitManager.RegisterConversion(DegreeCelcius, DegreeFahrenheit, delegate (Amount amount)
            {
                return new Amount(amount.Value * 9.0 / 5.0 + 32.0, DegreeFahrenheit);
            }
            );

            // Convert Fahrenheit to Celcius:
            UnitManager.RegisterConversion(DegreeFahrenheit, DegreeCelcius, delegate (Amount amount)
            {
                return new Amount((amount.Value - 32.0) / 9.0 * 5.0, DegreeCelcius);
            }
            );

            // Convert Celcius to Kelvin:
            UnitManager.RegisterConversion(DegreeCelcius, Kelvin, delegate (Amount amount)
            {
                return new Amount(amount.Value + 273.15, Kelvin);
            }
            );

            // Convert Kelvin to Celcius:
            UnitManager.RegisterConversion(Kelvin, DegreeCelcius, delegate (Amount amount)
            {
                return new Amount(amount.Value - 273.15, DegreeCelcius);
            }
            );

            // Convert Fahrenheit to Kelvin:
            UnitManager.RegisterConversion(DegreeFahrenheit, Kelvin, delegate (Amount amount)
            {
                return amount.ConvertedTo(DegreeCelcius).ConvertedTo(Kelvin);
            }
            );

            // Convert Kelvin to Fahrenheit:
            UnitManager.RegisterConversion(Kelvin, DegreeFahrenheit, delegate (Amount amount)
            {
                return amount.ConvertedTo(DegreeCelcius).ConvertedTo(DegreeFahrenheit);
            }
            );
        }

        #endregion Conversion functions
    }


    [UnitDefinitionClass]
    public static class PressureUnits
    {
        public static readonly Unit Pascal = new Unit("pascal", "Pa", ForceUnits.Newton * LengthUnits.Meter.Power(-2), "Pressure");
        //public static readonly Unit Pascalg = new Unit("pascal g", "Pa g", Pascal-Atmosphere, "Pressure");
        public static readonly Unit HectoPascal = new Unit("hectopascal", "hPa", 100.0 * Pascal, "Pressure");
        public static readonly Unit KiloPascal = new Unit("kilopascal", "KPa", 1000.0 * Pascal, "Pressure");
        public static readonly Unit Bar = new Unit("bar", "bar", 100000.0 * Pascal, "Pressure");
        public static readonly Unit MilliBar = new Unit("millibar", "mbar", 0.001 * Bar, "Pressure");
        public static readonly Unit Atmosphere = new Unit("atmosphere", "atm", 101325.0 * Pascal, "Pressure");

        public static readonly Unit KgPercm2 = new Unit("Kg/cm2", "Kg/cm2", 98.06652048 * KiloPascal, "Pressure");
        public static readonly Unit psi = new Unit("psi", "psi", 6.894759087 * KiloPascal, "Pressure");
        public static readonly Unit MeterWater = new Unit("Meter Water Column", "MCA", 9.806382778 * KiloPascal, "Pressure");
        public static readonly Unit InchWater = new Unit("Inch Water Column", "Inch WC", 0.249082008 * KiloPascal, "Pressure");
        public static readonly Unit centimeterWater = new Unit("centimeter Water Column", "cm WC", MeterWater * 100, "Pressure");
        public static readonly Unit feetWater = new Unit("Feet Water Column", "feet CA", KiloPascal * 2.988301699, "Pressure");

        public static readonly Unit InchHg = new Unit("inch Hg", "inch Hg", KiloPascal * 3.3863787, "Pressure");
        public static readonly Unit cmHg = new Unit("cm Hg", "cm Hg", KiloPascal * 1.332199, "Pressure");
        public static readonly Unit mmHg = new Unit("mm Hg", "mm Hg", KiloPascal * 0.133322, "Pressure");



    }

    [UnitDefinitionClass]
    public static class MotorVelocityUnits
    {
        public static readonly Unit Hertz = new Unit("Hertz", "Hz", TimeUnits.Second.Power(-1), "Frequency");
        public static readonly Unit MegaHerts = new Unit("MegaHertz", "Mhz", 1000000.0 * Hertz, "Frequency");
        public static readonly Unit RPM = new Unit("Rounds per minute", "rpm", TimeUnits.Minute.Power(-1), "Frequency");
        public static readonly Unit Percentage = new Unit("%", "%", SIUnitTypes.Percentage, "Frequency");
    }
    [UnitDefinitionClass]
    public static class PercentageUnits
    {
        public static readonly Unit Percentage = new Unit("%", "%", SIUnitTypes.Percentage, "Percentage");
    }
    [UnitDefinitionClass]
    public static class AmountOfSubstanceUnits
    {
        public static readonly Unit Mole = new Unit("mole", "mol", SIUnitTypes.AmountOfSubstance, "AmountOfSubstance");
        public static readonly Unit KMole = new Unit("Kmole", "Kmol", 1000 * Mole, "AmountOfSubstance");
        public static readonly Unit lbMole = new Unit("lbmole", "lbmol", KMole / 2.2, "AmountOfSubstance");
    }
    [UnitDefinitionClass]
    public static class LuminousIntensityUnits
    {
        public static readonly Unit Candela = new Unit("candela", "cd", SIUnitTypes.LuminousIntensity, "Louminous");
    }
    [UnitDefinitionClass]
    public static class HeatTransferCoefficientUnits
    {
        public static readonly Unit BTU_hr_ft2_F = new Unit("BTU/(hr*ft2*ºF)", "BTU/(hr*ft2*ºF)",
         EnergyUnits.BTU / TimeUnits.Hour / SurfaceUnits.Foot2 / TemperatureUnits.DegreeFahrenheit, "HeatTransferCoefficient");

        public static readonly Unit cal_seg_cm2_C = new Unit("cal/(seg*cm2*ºC)", "cal/(seg*cm2*ºC)",
            BTU_hr_ft2_F / 0.00013562299126, "HeatTransferCoefficient");

        public static readonly Unit Joul_seg_m2_C = new Unit("Joule/(seg*m2*ºC)", "J/(seg*m2*ºC)",
           BTU_hr_ft2_F / 5.678263398, "HeatTransferCoefficient");

        public static readonly Unit kcal_hr_m2_C = new Unit("Kcal/(hr*m2*ºC)", "kcal/(hr*m2*ºC)",
           BTU_hr_ft2_F / 4.8824276853, "HeatTransferCoefficient");

        public static readonly Unit kcal_hr_ft2_C = new Unit("Kcal/(hr*ft2*ºC)", "kcal/(hr*ft2*ºC)",
           BTU_hr_ft2_F / 0.45359237435, "HeatTransferCoefficient");

        public static readonly Unit Watt_m2_K = new Unit("Watt/(m2*K)", "Watt/(m2*K)",
           BTU_hr_ft2_F / 5.678263398, "HeatTransferCoefficient");

        public static readonly Unit Watt_m2_C = new Unit("Watt/(m2*°C)", "Watt/(m2*°C)",
          BTU_hr_ft2_F / 5.678263398, "HeatTransferCoefficient");
    }
    [UnitDefinitionClass]
    public static class MassDensityUnits
    {
        public static readonly Unit Kg_m3 = new Unit("Kg/m3", "Kg/m3", MassUnits.KiloGram / VolumeUnits.Meter3, "MassDensity");
        public static readonly Unit g_m3 = new Unit("g/m3", "g/m3", MassUnits.Gram / VolumeUnits.Meter3, "MassDensity");
        public static readonly Unit mg_m3 = new Unit("mg/m3", "mg/m3", MassUnits.MilliGram / VolumeUnits.Meter3, "MassDensity");
        public static readonly Unit Kg_cm3 = new Unit("Kg/cm3", "Kg/cm3", MassUnits.KiloGram / VolumeUnits.cMeter3, "MassDensity");
        public static readonly Unit g_cm3 = new Unit("g/cm3", "g/cm3", MassUnits.Gram / VolumeUnits.cMeter3, "MassDensity");
        public static readonly Unit mg_L = new Unit("mg/L", "mg/L", MassUnits.MilliGram / VolumeUnits.Liter, "MassDensity");
        public static readonly Unit g_L = new Unit("g/L", "g/L", MassUnits.Gram / VolumeUnits.Liter, "MassDensity");
        public static readonly Unit Kg_L = new Unit("Kg/L", "Kg/L", MassUnits.KiloGram / VolumeUnits.Liter, "MassDensity");
        public static readonly Unit lb_ft3 = new Unit("lb/ft3", "lb/ft3", MassUnits.Pound / VolumeUnits.Foot3, "MassDensity");
        public static readonly Unit lb_in3 = new Unit("lb/in3", "lb/in3", MassUnits.Pound / VolumeUnits.inch3, "MassDensity");
        public static readonly Unit lb_gal = new Unit("lb/gal", "lb/gal", MassUnits.Pound / VolumeUnits.Galon, "MassDensity");


    }
    [UnitDefinitionClass]
    public static class PressureDropLengthUnits
    {
        public static readonly Unit psi_100ft = new Unit("Pound/in2/100", "psi/100 ft", PressureDropUnits.psi / (100 * LengthUnits.Foot), "DropPressureLength");
        public static readonly Unit Kpa_m = new Unit("KiloPascal/meter", "kPa/m", PressureDropUnits.KiloPascal / (LengthUnits.Meter), "DropPressureLength");

    }
    [UnitDefinitionClass]
    public static class PressureDropUnits
    {
        public static readonly Unit Pascal = new Unit("Pascal", "Pa", ForceUnits.Newton * LengthUnits.Meter.Power(-2), "DropPressure");
        public static readonly Unit HectoPascal = new Unit("hectoPascal", "hPa", 100.0 * Pascal, "DropPressure");
        public static readonly Unit KiloPascal = new Unit("kiloPascal", "KPa", 1000.0 * Pascal, "DropPressure");
        public static readonly Unit Bar = new Unit("bar", "bar", 100000.0 * Pascal, "DropPressure");
        public static readonly Unit MilliBar = new Unit("millibar", "mbar", 0.001 * Bar, "DropPressure");
        public static readonly Unit Atmosphere = new Unit("atmosphere", "atm", 101325.0 * Pascal, "DropPressure");

        public static readonly Unit KgPercm2 = new Unit("Kg/cm2", "Kg/cm2", 98.06652048 * KiloPascal, "DropPressure");
        public static readonly Unit psi = new Unit("Pound/in2", "psi", 6.894759087 * KiloPascal, "DropPressure");

        public static readonly Unit MeterWater = new Unit("Meter Water Column", "MCA", 9.806382778 * KiloPascal, "DropPressure");
        public static readonly Unit InchWater = new Unit("Inch Water Column", "Inch WC", 0.249082008 * KiloPascal, "DropPressure");
        public static readonly Unit centimeterWater = new Unit("cMeter Water Column", "cm WC", MeterWater * 100, "DropPressure");
        public static readonly Unit feetWater = new Unit("Feet Water Column", "feet CA", KiloPascal * 2.988301699, "DropPressure");

        public static readonly Unit InchHg = new Unit("Inch Hg", "Inch Hg", KiloPascal * 3.3863787, "DropPressure");
        public static readonly Unit cmHg = new Unit("cm Hg", "cm Hg", KiloPascal * 1.332199, "DropPressure");
        public static readonly Unit mmHg = new Unit("mm Hg", "mm Hg", KiloPascal * 0.133322, "DropPressure");
    }
    [UnitDefinitionClass, UnitConversionClass]
    public static class ThermalConductivityUnits
    {
        public static readonly Unit W_m_K = new Unit("W/m/K", "W/m/K",
            PowerUnits.Watt / LengthUnits.Meter / TemperatureUnits.Kelvin, "ThermalConductivity");

        public static readonly Unit W_cm_C = new Unit("W/cm/°C", "W/cm/°C",
           W_m_K / 0.01, "ThermalConductivity");

        public static readonly Unit kW_m_K = new Unit("kW/m/K", "kW/m/K",
            W_m_K / 0.001, "ThermalConductivity");

        public static readonly Unit cal_sg_cm_C = new Unit("cal/sg/cm/°C", "cal/sg/cm/°C",
          W_m_K / 0.002388459, "ThermalConductivity");

        public static readonly Unit kcal_hr_m_C = new Unit("kcal/hr/m/°C", "kcal/hr/m/°C",
         W_m_K / 0.8598452279, "ThermalConductivity");

        public static readonly Unit BTU_in_sg_ft2_m_F = new Unit("BTU in/sg/ft2/°F", "BTU in/sg/ft2/°F",
         W_m_K / 0.0019259644, "ThermalConductivity");

        public static readonly Unit BTU_ft_hr_ft2_m_F = new Unit("BTU ft/hr/ft2/°F", "BTU ft/hr/ft2/°F",
        W_m_K / 0.5777893165, "ThermalConductivity");

        public static readonly Unit BTU_in_hr_ft2_m_F = new Unit("BTU in/hr/ft2/°F", "BTU in/hr/ft2/°F",
        W_m_K / 6.9334717985, "ThermalConductivity");

    }
    [UnitDefinitionClass]
    public static class VolumeEnergyUnits
    {
        public static readonly Unit J_m3 = new Unit("Joule/m3", "Joule/m3",
            EnergyUnits.Joule / VolumeUnits.Meter3, "VolumeEnergy");
        public static readonly Unit KJ_m3 = new Unit("KJoule/m3", "KJoule/m3",
           EnergyUnits.KiloJoule / VolumeUnits.Meter3, "VolumeEnergy");

        public static readonly Unit cal_m3 = new Unit("cal/m3", "cal/m3",
           EnergyUnits.Calorie / VolumeUnits.Meter3, "VolumeEnergy");
        public static readonly Unit Kcal_m3 = new Unit("KJoule/m3", "KJoule/m3",
           EnergyUnits.KiloCalorie / VolumeUnits.Meter3, "VolumeEnergy");

        public static readonly Unit BTU_ft3 = new Unit("BTU/ft3", "BTU/ft3",
          EnergyUnits.BTU / VolumeUnits.Foot3, "VolumeEnergy");

        public static readonly Unit BTU_in3 = new Unit("BTU/in3", "BTU/in3",
         EnergyUnits.BTU / VolumeUnits.inch3, "VolumeEnergy");

        public static readonly Unit BTU_gal = new Unit("BTU/gal", "BTU/gal",
         EnergyUnits.BTU / VolumeUnits.Galon, "VolumeEnergy");

    }
    [UnitDefinitionClass]
    public static class MassEnergyUnits
    {
        public static readonly Unit J_Kg = new Unit("Joule/Kg", "Joule/Kg",
            EnergyUnits.Joule / MassUnits.KiloGram, "MassEnergy");
        public static readonly Unit J_g = new Unit("Joule/g", "Joule/g",
           EnergyUnits.Joule / MassUnits.Gram, "MassEnergy");

        public static readonly Unit KJ_Kg = new Unit("KJoule/Kg", "KJoule/Kg",
           EnergyUnits.KiloJoule / MassUnits.KiloGram, "MassEnergy");
        public static readonly Unit KJ_g = new Unit("KJoule/g", "KJoule/g",
          EnergyUnits.KiloJoule / MassUnits.Gram, "MassEnergy");


        public static readonly Unit cal_Kg = new Unit("cal/Kg", "cal/Kg",
           EnergyUnits.Calorie / MassUnits.KiloGram, "MassEnergy");
        public static readonly Unit cal_g = new Unit("cal/g", "cal/g",
          EnergyUnits.Calorie / MassUnits.Gram, "MassEnergy");

        public static readonly Unit Kcal_Kg = new Unit("Kcal/Kg", "Kcal/Kg",
          EnergyUnits.KiloCalorie / MassUnits.KiloGram, "MassEnergy");
        public static readonly Unit Kcal_g = new Unit("Kcal/g", "Kcal/g",
          EnergyUnits.KiloCalorie / MassUnits.Gram, "MassEnergy");


        public static readonly Unit BTU_lb = new Unit("BTU/lb", "BTU/lb",
          EnergyUnits.BTU / MassUnits.Pound, "MassEnergy");



    }
    [UnitDefinitionClass]
    public static class MassEntropyUnits
    {

        public static readonly Unit BTU_lb_F = new Unit("BTU/lb/°F", "BTU/lb/°F",
          EnergyUnits.BTU / MassUnits.Pound / TemperatureUnits.DegreeFahrenheit, "MassEntropy");

        public static readonly Unit KJ_Kg_C = new Unit("KJoule/Kg/°C", "KJoule/Kg/°C",
           BTU_lb_F / 4.1868, "MassEntropy");

        public static readonly Unit J_g_C = new Unit("Joule/g/°C", "Joule/g/°C",
           KJ_Kg_C, "MassEntropy");

        public static readonly Unit J_Kg_C = new Unit("Joule/Kg/°C", "Joule/Kg/°C",
             BTU_lb_F / 4186.8, "MassEntropy");



        public static readonly Unit cal_g_C = new Unit("cal/g/°C", "cal/g/°C",
       BTU_lb_F / 1, "MassEntropy");

        public static readonly Unit Kcal_Kg_C = new Unit("Kcal/Kg/°C", "Kcal/Kg/°C",
          BTU_lb_F / 1, "MassEntropy");



    }
    [UnitDefinitionClass]
    public static class MassFlowUnits
    {
        public static readonly Unit Kg_min = new Unit("Kg/min", "Kg/min",
        MassUnits.KiloGram / TimeUnits.Minute, "MassFlow");
        public static readonly Unit Kg_sg = new Unit("Kg/sg", "Kg/sg",
        MassUnits.KiloGram / TimeUnits.Second, "MassFlow");
        public static readonly Unit Kg_hr = new Unit("Kg/hr", "Kg/hr",
         MassUnits.KiloGram / TimeUnits.Hour, "MassFlow");
        public static readonly Unit Kg_day = new Unit("Kg/day", "Kg/day",
         MassUnits.KiloGram / TimeUnits.Day, "MassFlow");
        public static readonly Unit Kg_Month = new Unit("Kg/month", "Kg/mo",
         MassUnits.KiloGram / TimeUnits.Month, "MassFlow");
        public static readonly Unit Kg_Year = new Unit("Kg/Year", "Kg/yr",
         MassUnits.KiloGram / TimeUnits.Year, "MassFlow");

        public static readonly Unit Ton_min = new Unit("Ton/min", "Ton/min",
        MassUnits.KiloGram / TimeUnits.Minute, "MassFlow");
        public static readonly Unit Ton_sg = new Unit("Ton/sg", "Ton/sg",
        MassUnits.KiloGram / TimeUnits.Second, "MassFlow");
        public static readonly Unit Ton_hr = new Unit("Ton/hr", "Ton/hr",
         MassUnits.Ton / TimeUnits.Hour, "MassFlow");
        public static readonly Unit Ton_day = new Unit("Ton/day", "Ton/day",
         MassUnits.Ton / TimeUnits.Day, "MassFlow");
        public static readonly Unit Ton_Month = new Unit("Ton/month", "Ton/mo",
         MassUnits.Ton / TimeUnits.Hour, "MassFlow");
        public static readonly Unit Ton_Year = new Unit("Ton/Year", "Ton/yr",
         MassUnits.Ton / TimeUnits.Year, "MassFlow");


        public static readonly Unit lb_min = new Unit("lb/min", "lb/min",
        MassUnits.Pound / TimeUnits.Minute, "MassFlow");
        public static readonly Unit lb_sg = new Unit("lb/sg", "lb/sg",
        MassUnits.Pound / TimeUnits.Second, "MassFlow");

        public static readonly Unit lb_hr = new Unit("lb/hr", "lb/hr",
         MassUnits.Pound / TimeUnits.Hour, "MassFlow");
        public static readonly Unit lb_day = new Unit("lb/day", "lb/day",
         MassUnits.Pound / TimeUnits.Day, "MassFlow");
        public static readonly Unit lb_Month = new Unit("lb/month", "lb/mo",
         MassUnits.Pound / TimeUnits.Hour, "MassFlow");
        public static readonly Unit lb_Year = new Unit("lb/Year", "lb/yr",
         MassUnits.Pound / TimeUnits.Year, "MassFlow");
    }
    [UnitDefinitionClass]
    public static class HeatSurfaceFlowUnits
    {
        public static readonly Unit W_m2 = new Unit("W/m2", "W/m2",
           PowerUnits.Watt / SurfaceUnits.Meter2, "HeatSurfaceFlow");
        public static readonly Unit KW_m2 = new Unit("KW/m2", "KW/m2",
           PowerUnits.KiloWatt / SurfaceUnits.Meter2, "HeatSurfaceFlow");
        public static readonly Unit BTU_hr_ft2 = new Unit("BTU/(hr*ft2)", "BTU/(hr*ft2)",
           EnergyUnits.BTU / TimeUnits.Hour / SurfaceUnits.Foot2, "HeatSurfaceFlow");

    }
    [UnitDefinitionClass]
    public static class VolumetricFlowUnits
    {
        public static readonly Unit m3_min = new Unit("m3/min", "m3/min",
        VolumeUnits.Meter3 / TimeUnits.Minute, "VolumetricFlow");
        public static readonly Unit m3_sg = new Unit("m3/sg", "m3/sg",
        VolumeUnits.Meter3 / TimeUnits.Second, "VolumetricFlow");
        public static readonly Unit m3_hr = new Unit("m3/hr", "m3/hr",
         VolumeUnits.Meter3 / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit m3_day = new Unit("m3/day", "m3/day",
         VolumeUnits.Meter3 / TimeUnits.Day, "VolumetricFlow");
        public static readonly Unit m3_Month = new Unit("m3/month", "m3/mo",
         VolumeUnits.Meter3 / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit m3_Year = new Unit("m3/Year", "m3/yr",
         VolumeUnits.Meter3 / TimeUnits.Year, "VolumetricFlow");

        public static readonly Unit Lt_min = new Unit("Lt/min", "Lt/min",
        VolumeUnits.Liter / TimeUnits.Minute, "VolumetricFlow");
        public static readonly Unit Lt_sg = new Unit("Lt/sg", "Lt/sg",
        VolumeUnits.Liter / TimeUnits.Second, "VolumetricFlow");
        public static readonly Unit Lt_hr = new Unit("Lt/hr", "Lt/hr",
         VolumeUnits.Liter / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit Lt_day = new Unit("Lt/day", "Lt/day",
         VolumeUnits.Liter / TimeUnits.Day, "VolumetricFlow");
        public static readonly Unit Lt_Month = new Unit("Lt/month", "Lt/mo",
         VolumeUnits.Liter / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit Lt_Year = new Unit("Lt/Year", "Lt/yr",
         VolumeUnits.Liter / TimeUnits.Year, "VolumetricFlow");

        public static readonly Unit gal_min = new Unit("gal/min", "gal/min",
        VolumeUnits.Galon / TimeUnits.Minute, "VolumetricFlow");
        public static readonly Unit gal_sg = new Unit("gal/sg", "gal/sg",
        VolumeUnits.Galon / TimeUnits.Second, "VolumetricFlow");
        public static readonly Unit gal_hr = new Unit("gal/hr", "gal/hr",
         VolumeUnits.Galon / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit gal_day = new Unit("gal/day", "gal/day",
         VolumeUnits.Galon / TimeUnits.Day, "VolumetricFlow");
        public static readonly Unit gal_Month = new Unit("gal/month", "gal/mo",
         VolumeUnits.Galon / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit gal_Year = new Unit("gal/Year", "gal/yr",
         VolumeUnits.Galon / TimeUnits.Year, "VolumetricFlow");

        public static readonly Unit ft3_min = new Unit("ft3/min", "ft3/min",
        VolumeUnits.Foot3 / TimeUnits.Minute, "VolumetricFlow");
        public static readonly Unit ft3_sg = new Unit("ft3/sg", "ft3/sg",
        VolumeUnits.Foot3 / TimeUnits.Second, "VolumetricFlow");
        public static readonly Unit ft3_hr = new Unit("ft3/hr", "ft3/hr",
         VolumeUnits.Foot3 / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit ft3_day = new Unit("ft3/day", "ft3/day",
         VolumeUnits.Foot3 / TimeUnits.Day, "VolumetricFlow");
        public static readonly Unit ft3_Month = new Unit("ft3/month", "ft3/mo",
         VolumeUnits.Foot3 / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit ft3_Year = new Unit("ft3/Year", "ft3/yr",
         VolumeUnits.Foot3 / TimeUnits.Year, "VolumetricFlow");

        public static readonly Unit barrel_min = new Unit("barrel/min", "barrel/min",
        VolumeUnits.Barrel / TimeUnits.Minute, "VolumetricFlow");
        public static readonly Unit barrel_sg = new Unit("barrel/sg", "barrel/sg",
        VolumeUnits.Barrel / TimeUnits.Second, "VolumetricFlow");
        public static readonly Unit barrel_hr = new Unit("barrel/hr", "barrel/hr",
         VolumeUnits.Barrel / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit barrel_day = new Unit("barrel/day", "barrel/day",
         VolumeUnits.Barrel / TimeUnits.Day, "VolumetricFlow");
        public static readonly Unit barrel_Month = new Unit("barrel/month", "barrel/mo",
         VolumeUnits.Barrel / TimeUnits.Hour, "VolumetricFlow");
        public static readonly Unit barrel_Year = new Unit("barrel/Year", "barrel/yr",
         VolumeUnits.Barrel / TimeUnits.Year, "VolumetricFlow");

    }
    [UnitDefinitionClass]
    public static class EnergyFlowUnits
    {
        public static readonly Unit J_min = new Unit("J/min", "J/min",
       EnergyUnits.Joule / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit J_sg = new Unit("J/sg", "J/sg",
        EnergyUnits.Joule / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit J_hr = new Unit("J/hr", "J/hr",
         EnergyUnits.Joule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit J_day = new Unit("J/day", "J/day",
         EnergyUnits.Joule / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit J_Month = new Unit("J/month", "J/mo",
         EnergyUnits.Joule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit J_Year = new Unit("J/Year", "J/yr",
         EnergyUnits.Joule / TimeUnits.Year, "EnergyFlow");

        public static readonly Unit KJ_min = new Unit("KJ/min", "KJ/min",
       EnergyUnits.KiloJoule / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit KJ_sg = new Unit("KJ/sg", "KJ/sg",
        EnergyUnits.KiloJoule / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit KJ_hr = new Unit("KJ/hr", "KJ/hr",
         EnergyUnits.KiloJoule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit KJ_day = new Unit("KJ/day", "KJ/day",
         EnergyUnits.KiloJoule / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit KJ_Month = new Unit("KJ/month", "KJ/mo",
         EnergyUnits.KiloJoule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit KJ_Year = new Unit("KJ/Year", "KJ/yr",
         EnergyUnits.KiloJoule / TimeUnits.Year, "EnergyFlow");

        public static readonly Unit MJ_min = new Unit("MJ/min", "MJ/min",
       EnergyUnits.MegaJoule / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit MJ_sg = new Unit("MJ/sg", "MJ/sg",
        EnergyUnits.MegaJoule / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit MJ_hr = new Unit("MJ/hr", "MJ/hr",
         EnergyUnits.MegaJoule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit MJ_day = new Unit("MJ/day", "MJ/day",
         EnergyUnits.MegaJoule / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit MJ_Month = new Unit("MJ/month", "MJ/mo",
         EnergyUnits.MegaJoule / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit MJ_Year = new Unit("MJ/Year", "MJ/yr",
         EnergyUnits.MegaJoule / TimeUnits.Year, "EnergyFlow");

        public static readonly Unit cal_min = new Unit("cal/min", "cal/min",
       EnergyUnits.Calorie / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit cal_sg = new Unit("cal/sg", "cal/sg",
        EnergyUnits.Calorie / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit cal_hr = new Unit("cal/hr", "cal/hr",
         EnergyUnits.Calorie / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit cal_day = new Unit("cal/day", "cal/day",
         EnergyUnits.Calorie / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit cal_Month = new Unit("cal/month", "cal/mo",
         EnergyUnits.Calorie / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit cal_Year = new Unit("cal/Year", "cal/yr",
         EnergyUnits.Calorie / TimeUnits.Year, "EnergyFlow");

        public static readonly Unit Kcal_min = new Unit("Kcal/min", "Kcal/min",
       EnergyUnits.KiloCalorie / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit Kcal_sg = new Unit("Kcal/sg", "Kcal/sg",
        EnergyUnits.KiloCalorie / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit Kcal_hr = new Unit("Kcal/hr", "Kcal/hr",
         EnergyUnits.KiloCalorie / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit Kcal_day = new Unit("Kcal/day", "Kcal/day",
         EnergyUnits.KiloCalorie / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit Kcal_Month = new Unit("Kcal/month", "Kcal/mo",
         EnergyUnits.KiloCalorie / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit Kcal_Year = new Unit("Kcal/Year", "Kcal/yr",
         EnergyUnits.KiloCalorie / TimeUnits.Year, "EnergyFlow");

        public static readonly Unit BTUmin = new Unit("BTU/min", "BTU/min",
       EnergyUnits.BTU / TimeUnits.Minute, "EnergyFlow");
        public static readonly Unit BTUsg = new Unit("BTU/sg", "BTU/sg",
        EnergyUnits.BTU / TimeUnits.Second, "EnergyFlow");
        public static readonly Unit BTUhr = new Unit("BTU/hr", "BTU/hr",
         EnergyUnits.BTU / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit BTUday = new Unit("BTU/day", "BTU/day",
         EnergyUnits.BTU / TimeUnits.Day, "EnergyFlow");
        public static readonly Unit BTUMonth = new Unit("BTU/month", "BTU/mo",
         EnergyUnits.BTU / TimeUnits.Hour, "EnergyFlow");
        public static readonly Unit BTUYear = new Unit("BTU/Year", "BTU/yr",
         EnergyUnits.BTU / TimeUnits.Year, "EnergyFlow");


    }
    [UnitDefinitionClass]
    public static class ViscosityUnits
    {
        public static readonly Unit Pa_s = new Unit("Pascal*second", "Pa*sg",
         PressureUnits.Pascal * TimeUnits.Second, "Viscosity");

        public static readonly Unit Poise = new Unit("Poise", "ps",
        Pa_s * 0.1, "Viscosity");

        public static readonly Unit cPoise = new Unit("cPoise", "cps",
        Poise * 0.01, "Viscosity");

        public static readonly Unit Kg_m_s = new Unit("Kg*m*seg", "Kg*m*seg",
        Pa_s, "Viscosity");

        public static readonly Unit Nt_seg_m2 = new Unit("Newton*seg/m2", "Newton*seg/m2",
       Pa_s, "Viscosity");

        public static readonly Unit lb_ft_sg = new Unit("lb*ft*seg", "lb*ft*seg",
       Pa_s * 1.4882, "Viscosity");

        public static readonly Unit lb_ft_hr = new Unit("lb*ft*hr", "lb*ft*hr",
       Pa_s * 0.00041338, "Viscosity");

    }
}

