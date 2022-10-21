





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.UnitsSystem;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    public class AddUnit : AddCommand
    {
       

        public string? UnitName { get; set; }
        public double Value { get; set; }
       
     
    }
}
