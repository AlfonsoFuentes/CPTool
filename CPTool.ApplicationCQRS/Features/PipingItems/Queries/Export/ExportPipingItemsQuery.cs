using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.Export
{

    public class ExportPipingItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandPipingItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandPipingItem, object?>> Dictionary = new Dictionary<string, Func<CommandPipingItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Tag Id",item => item.TagId}
            ,
                    { "Pipe Class",item => item.ClassName}
            ,
                    { "Diameter",item => item.DiameterName}
            ,
                    { "Material",item => item.MaterialName}
            ,
                    { "Process Fluid",item => item.ProcessFluidName}
            ,
                    { "Insulation",item => item.Insulation}
            ,
                    { "Tag Number",item => item.TagNumber}
            ,
                    { "Item Start",item => item.StartMWOItemName}
            ,
                    { "Nozzle Start",item => item.NozzleStartName}
            ,
                    { "Item End",item => item.FinishMWOItemName}
            ,
                    { "Nozzle End",item => item.NozzleFinishName}
            ,
                    { "Pressure",item => item.pProcessCondition!.Pressure!.StringValue}
            ,
                    { "Temperature",item => item.pProcessCondition!.Temperature!.StringValue}
            ,
                    { "Mass Flow",item => item.pProcessCondition!.MassFlow!.StringValue}
            ,
                    { "Volumetric Flow",item => item.pProcessCondition!.VolumetricFlow!.StringValue}
            ,
                    { "Density",item => item.pProcessCondition!.Density!.StringValue}
            ,
                    { "Viscosity",item => item.pProcessCondition!.Viscosity!.StringValue}
            ,
                    { "Specific Enthalpy",item => item.pProcessCondition!.SpecificEnthalpy!.StringValue}
            ,
                    { "Enthalpy Flow",item => item.pProcessCondition!.EnthalpyFlow!.StringValue}
            ,
                    { "Specific Cp",item => item.pProcessCondition!.SpecificCp!.StringValue}
            ,
                    { "Thermal Conductivity",item => item.pProcessCondition!.ThermalConductivity!.StringValue}

                };
    }
}
