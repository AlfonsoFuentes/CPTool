using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Queries.Export
{

    public class ExportInstrumentItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandInstrumentItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandInstrumentItem, object?>> Dictionary = new Dictionary<string, Func<CommandInstrumentItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Tag Id",item => item.TagId} ,
                    { "Brand",item => item.BrandName}
            ,
                    { "Vendor",item => item.SupplierName}
,
                    { "Model",item => item.Model}
            ,
                    { "Reference",item => item.Reference}
            ,
                    { "Serial Number",item => item.SerialNumber}
            ,
                    { "Process Fluid",item => item.ProcessFluidName}
            ,
                    { "Gasket",item => item.GasketName}
            ,
                    { "Inner Material",item => item.InnerMaterialName}
            ,
                    { "Outer Material",item => item.OuterMaterialName} ,
                    { "Pressure",item => item.iProcessCondition!.Pressure!.StringValue}
            ,
                    { "Temperature",item => item.iProcessCondition!.Temperature!.StringValue}
            ,
                    { "Mass Flow",item => item.iProcessCondition!.MassFlow!.StringValue}
            ,
                    { "Volumetric Flow",item => item.iProcessCondition!.VolumetricFlow!.StringValue}
            ,
                    { "Density",item => item.iProcessCondition!.Density!.StringValue}
            ,
                    { "Viscosity",item => item.iProcessCondition!.Viscosity!.StringValue}
            ,
                    { "Specific Enthalpy",item => item.iProcessCondition!.SpecificEnthalpy!.StringValue}
            ,
                    { "Enthalpy Flow",item => item.iProcessCondition!.EnthalpyFlow!.StringValue}
            ,
                    { "Specific Cp",item => item.iProcessCondition!.SpecificCp!.StringValue}
            ,
                    { "Thermal Conductivity",item => item.iProcessCondition!.ThermalConductivity!.StringValue}


                };
    }
}
