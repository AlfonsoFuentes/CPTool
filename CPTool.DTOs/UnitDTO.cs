using CPTool.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = CPTool.UnitsSystem.Unit;

namespace CPTool.DTOS
{
    public class UnitDTO :  AuditableEntityDTO, IMapFrom<Unit>
    {
        public UnitDTO()
        {
            Amount = new UnitLess(UnitLessUnits.None);
        }
        public UnitDTO(Unit unit)
        {
            Amount = new(unit);
        }
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

        Amount? Amount { get; init; }
        public List<PipeDiameterDTO>? ODsDTO { get; set; } = null!;

        public List<PipeDiameterDTO>? IDsDTO { get; set; }  = null!;

        public List<PipeDiameterDTO>? ThicknesssDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? SpecificCpsDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? ThermalConductivitysDTO { get; set; }  = null!;


        public List<ProcessConditionDTO>? SpecificEnthalpysDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? EnthalpyFlowsDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? ViscositysDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? DensitysDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? VolumetricFlowsDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? MassFlowsDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? TemperaturesDTO { get; set; }  = null!;

        public List<ProcessConditionDTO>? PressuresDTO { get; set; }  = null!;

        public List<PipeAccesoryDTO>? FrictionPipeAccesorysDTO { get; set; } = null!;

        public List<PipeAccesoryDTO>? ReynoldPipeAccesorysDTO { get; set; } = null!;

        public List<PipeAccesoryDTO>? LevelInletPipeAccesorysDTO { get; set; }  = null!;

        public List<PipeAccesoryDTO>? LevelOutletPipeAccesorysDTO { get; set; }  = null!;

        public List<PipeAccesoryDTO>? FrictionDropPressurePipeAccesorysDTO { get; set; }  = null!;

        public List<PipeAccesoryDTO>? OverallDropPressurePipeAccesorysDTO { get; set; }  = null!;

        public List<PipeAccesoryDTO>? ElevationChangePipeAccesorysDTO { get; set; }  = null!;
        
    }
}
