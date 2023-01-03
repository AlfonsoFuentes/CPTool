using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.Export
{

    public class ExportProcessConditionsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandProcessCondition> List { get; set; } = new();
        public Dictionary<string, Func<CommandProcessCondition, object?>> Dictionary = new Dictionary<string, Func<CommandProcessCondition, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}
            ,
                    { "Pressure",item => item.Pressure!.StringValue}
            ,
                    { "Temperature",item => item.Temperature!.StringValue}
            ,
                    { "Mass Flow",item => item.MassFlow!.StringValue}
            ,
                    { "Volumetric Flow",item => item.VolumetricFlow!.StringValue}
            ,
                    { "Density",item => item.Density!.StringValue}
            ,
                    { "Viscosity",item => item.Viscosity!.StringValue}
            ,
                    { "Specific Enthalpy",item => item.SpecificEnthalpy!.StringValue}
            ,
                    { "Enthalpy Flow",item => item.EnthalpyFlow!.StringValue}
            ,
                    { "Specific Cp",item => item.SpecificCp!.StringValue}
            ,
                    { "Thermal Conductivity",item => item.ThermalConductivity!.StringValue}

                };
    }
}
