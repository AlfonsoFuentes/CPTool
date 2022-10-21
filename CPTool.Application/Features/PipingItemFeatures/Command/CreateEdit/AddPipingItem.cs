





using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    public class AddPipingItem : AddCommand
    {
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

        public string TagNumber { get; set; } = "";
    }
}
