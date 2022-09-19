using CPTool.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class UnitDTO :  AuditableEntityDTO
    {
        public string? UnitName
        {
            get
            {
                return Amount!.UnitName;
            }
            set
            {
                Amount!.UnitName=value;
            }
        }
        public double Value
        {
            get
            {
                return Amount!.Value;
            }
            set
            {
                Amount!.SetValue(Amount!.Value, Amount!.UnitName);
            }
        }

        public Amount? Amount { get; init; }
        public List<PipeDiameterDTO>? ODsDTO { get; set; } = new();

        public List<PipeDiameterDTO>? IDsDTO { get; set; } = new();

        public List<PipeDiameterDTO>? ThicknesssDTO { get; set; } = new();



        public List<ProcessConditionDTO>? SpecificCpsDTO { get; set; } = new();

        public List<ProcessConditionDTO>? ThermalConductivitysDTO { get; set; } = new();


        public List<ProcessConditionDTO>? SpecificEnthalpysDTO { get; set; } = new();

        public List<ProcessConditionDTO>? EnthalpyFlowsDTO { get; set; } = new();

        public List<ProcessConditionDTO>? ViscositysDTO { get; set; } = new();

        public List<ProcessConditionDTO>? DensitysDTO { get; set; } = new();

        public List<ProcessConditionDTO>? VolumetricFlowsDTO { get; set; } = new();

        public List<ProcessConditionDTO>? MassFlowsDTO { get; set; } = new();

        public List<ProcessConditionDTO>? TemperaturesDTO { get; set; } = new();

        public List<ProcessConditionDTO>? PressuresDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? FrictionPipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? ReynoldPipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? LevelInletPipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? LevelOutletPipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? FrictionDropPressurePipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? OverallDropPressurePipeAccesorysDTO { get; set; } = new();

        public List<PipeAccesoryDTO>? ElevationChangePipeAccesorysDTO { get; set; } = new();
        
    }
}
