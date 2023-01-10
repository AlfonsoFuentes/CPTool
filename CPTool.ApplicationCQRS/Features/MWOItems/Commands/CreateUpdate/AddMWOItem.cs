



using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;


namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class AddMWOItem
    {

        public List<AddSignal> Signals { get; set; } = new();
        public string Name { get; set; } = string.Empty;
        public int? MWOId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public double BudgetPrize { get; set; }
        public double RealPrize { get; set; }
      
        public double Quantity { get; set; }
        public string? TagId { get; set; }
        public int? ChapterId { get; set; }
       
        public bool Existing { get; set; }
        public bool BudgetItem { get; set; }
        public int? ProcessFluidId { get; set; }
        public int? InnerMaterialId { get; set; }

        public int? MaterialOuterId { get; set; }

        public int? EquipmentTypeId { get; set; }

        public int? EquipmentTypeSubId { get; set; }

        public int? BrandId { get; set; }

        public int? SupplierId { get; set; }

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";

        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public int? MeasuredVariableId { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public int? DeviceFunctionId { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public int? ReadoutId { get; set; }

       
        public int? DiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }
        public int? PipeClassId { get; set; }
      
        public bool Insulation { get; set; }
        public List<AddNozzle>? Nozzles { get; set; }
        public List<CommandPropertySpecification>? PropertySpecifications { get; set; } 
        public List<AddPipeAccesory> PipeAccesorys { get; set; } = new(); 
        public string CostCenter { get; set; } = string.Empty;
        public double Assigned { get; set; }
    }
    public class UpdateMWOItem
    {


        public string Name { get; set; } = string.Empty;
        public int? MWOId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public double BudgetPrize { get; set; }
        public double RealPrize { get; set; }
      
        public double Quantity { get; set; }
        public string? TagId { get; set; }
        public int? ChapterId { get; set; }
        public bool BudgetItem { get; set; }
        public bool Existing { get; set; }
        public int? ProcessFluidId { get; set; }
        public int? InnerMaterialId { get; set; }
        public int? MaterialOuterId { get; set; }
        public int? EquipmentTypeId { get; set; }
        public int? EquipmentTypeSubId { get; set; }
        public int? BrandId { get; set; }

        public int? SupplierId { get; set; }

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
       
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

        public int? MeasuredVariableId { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public int? DeviceFunctionId { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public int? ReadoutId { get; set; }

        public int? DiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }
        public int? PipeClassId { get; set; }

        public bool Insulation { get; set; }
        public double Assigned { get; set; }
        public string CostCenter { get; set; } = string.Empty;
    }

}
