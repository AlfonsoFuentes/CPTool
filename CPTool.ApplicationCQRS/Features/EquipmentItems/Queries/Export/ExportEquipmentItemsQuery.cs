using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Queries.Export
{

    public class ExportEquipmentItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandEquipmentItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandEquipmentItem, object?>> Dictionary = new Dictionary<string, Func<CommandEquipmentItem, object?>>()
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
                    { "Pressure",item => item.eProcessCondition!.Pressure!.StringValue}
            ,
                    { "Temperature",item => item.eProcessCondition!.Temperature!.StringValue}
            ,
                    { "Mass Flow",item => item.eProcessCondition!.MassFlow!.StringValue}
            ,
                    { "Volumetric Flow",item => item.eProcessCondition!.VolumetricFlow!.StringValue}
            ,
                    { "Density",item => item.eProcessCondition!.Density!.StringValue}
            ,
                    { "Viscosity",item => item.eProcessCondition!.Viscosity!.StringValue}
            ,
                    { "Specific Enthalpy",item => item.eProcessCondition!.SpecificEnthalpy!.StringValue}
            ,
                    { "Enthalpy Flow",item => item.eProcessCondition!.EnthalpyFlow!.StringValue}
            ,
                    { "Specific Cp",item => item.eProcessCondition!.SpecificCp!.StringValue}
            ,
                    { "Thermal Conductivity",item => item.eProcessCondition!.ThermalConductivity!.StringValue}



                };
    }
}
