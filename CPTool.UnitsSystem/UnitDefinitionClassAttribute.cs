using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.UnitsSystem
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UnitDefinitionClassAttribute : Attribute
    {
    }

    /// <summary>
    /// Attribute to mark classes having static methods that register
    /// conversion functions. The UnitConvert class uses this attribute to
    /// identify classes with unit conversion methods in its RegisterConversions
    /// method.
    /// </summary>
    /// <see cref="UnitManager.RegisterConversions(System.Reflection.Assembly)"/>
    [AttributeUsage(AttributeTargets.Class)]
    public class UnitConversionClassAttribute : Attribute
    {
    }
}
