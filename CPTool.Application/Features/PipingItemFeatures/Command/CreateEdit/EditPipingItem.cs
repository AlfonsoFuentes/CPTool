using AutoMapper.Execution;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    public class EditPipingItem : EditCommand
    {
        public List<EditPipeAccesory> PipeAccesorys { get; set; } = new();
        public List<EditNozzle>? Nozzles { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition?.Id == 0 ? null : pProcessCondition?.Id;
        public EditProcessCondition? pProcessCondition { get; set; } = new();
        public int? pMaterialId => pMaterial?.Id == 0 ? null : pMaterial?.Id;
        public EditMaterial? pMaterial { get; set; } = new();
        public int? pProcessFluidId => pProcessFluid?.Id == 0 ? null : pProcessFluid?.Id;
        public EditProcessFluid? pProcessFluid { get; set; } = new();
        public int? pDiameterId => pDiameter?.Id == 0 ? null : pDiameter?.Id;
        public EditPipeDiameter? pDiameter { get; set; } = new();
        public int? NozzleStartId => NozzleStart?.Id == 0 ? null : NozzleStart?.Id;
        public EditNozzle? NozzleStart { get; set; } 
        public int? NozzleFinishId => NozzleFinish?.Id == 0 ? null : NozzleFinish?.Id;
        public EditNozzle? NozzleFinish { get; set; } 
        public int? StartMWOItemId => StartMWOItem?.Id == 0 ? null : StartMWOItem?.Id;
        public EditMWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId => FinishMWOItem?.Id == 0 ? null : FinishMWOItem?.Id;
        public EditMWOItem? FinishMWOItem { get; set; } 
        public int? pPipeClassId => pPipeClass?.Id == 0 ? null : pPipeClass?.Id;
        public EditPipeClass? pPipeClass { get; set; } = new();
        public string TagId => SetTagId();
        public bool Insulation { get; set; }
        public string TagNumber { get; set; } = "";
        
        string SetTagId()
        {
            if (pDiameter == null) return "";
            if (pMaterial == null) return $"{pDiameter?.Name}";
            if (pProcessFluid == null) return $"{pDiameter?.Name}-{pMaterial?.Abbreviation}";
            if (TagNumber == "") return $"{pDiameter?.Name}-{pMaterial?.Abbreviation}-{pProcessFluid?.TagLetter}";

            var tag =$"{pDiameter?.Name}-{pMaterial?.Abbreviation}-{pProcessFluid?.TagLetter}-{TagNumber}-{(Insulation ? 1 : 0)}";

            return tag;
        }
        

    }
}
