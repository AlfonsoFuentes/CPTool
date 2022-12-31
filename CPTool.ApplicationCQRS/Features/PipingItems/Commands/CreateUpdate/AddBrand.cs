using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class AddPipingItem
    {

       public int Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        public List<AddPipeAccesory>? PipeAccesorys { get; set; }
        public AddProcessCondition? pProcessCondition { get; set; }
        public int? pMaterialId { get; set; }
        public int? pProcessFluidId { get; set; }
        public int? pDiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }
        public int? pPipeClassId { get; set; }
        public string TagId { get; set; } = String.Empty;
        public bool Insulation { get; set; }
        public List<AddNozzle>? Nozzles { get; set; }
        public string TagNumber { get; set; } = "";
    }
    public class UpdatePipingItem
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UpdatePipeAccesory>? PipeAccesorys { get; set; }
      
        public int? pMaterialId { get; set; }
        public int? pProcessFluidId { get; set; }
        public int? pDiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }
        public int? pPipeClassId { get; set; }
        public string TagId { get; set; } = String.Empty;
        public bool Insulation { get; set; }
        public List<AddNozzle>? Nozzles { get; set; }
        public string TagNumber { get; set; } = "";
    }
}
