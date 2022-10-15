using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    public class EditPipingItem : EditCommand, IRequest<Result<int>>
    {
        public List<EditNozzle>? Nozzles { get; set; } = new();
        public List<EditMWOItem>? MWOItems { get; set; } = new();
        public List<EditPipeAccesory>? PipeAccesorys { get; set; } = new();
        public int? MaterialId => MaterialCommand?.Id == 0 ? null : MaterialCommand?.Id;
        public EditMaterial? MaterialCommand { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand?.Id == 0 ? null : ProcessFluidCommand?.Id;
        public EditProcessFluid? ProcessFluidCommand { get; set; }
        public int? DiameterId => DiameterCommand?.Id == 0 ? null : DiameterCommand?.Id;
        public EditPipeDiameter? DiameterCommand { get; set; }
        public int? NozzleStartId => NozzleStartCommand?.Id == 0 ? null : NozzleStartCommand?.Id;
        public EditNozzle? NozzleStartCommand { get; set; }
        public int? NozzleFinishId => NozzleFinishCommand?.Id == 0 ? null : NozzleFinishCommand?.Id;
        public EditNozzle? NozzleFinishCommand { get; set; }
        public int? StartMWOItemId => StartMWOItemCommand?.Id == 0 ? null : StartMWOItemCommand?.Id;
        public EditMWOItem? StartMWOItemCommand { get; set; }
        public int? FinishMWOItemId => FinishMWOItemCommand?.Id == 0 ? null : FinishMWOItemCommand?.Id;
        public EditMWOItem? FinishMWOItemCommand { get; set; }
        public int? PipeClassId => PipeClassCommand?.Id == 0 ? null : PipeClassCommand?.Id;
        public EditPipeClass? PipeClassCommand { get; set; }
        public string TagId { get; set; } = String.Empty;
        public bool Insulation { get; set; }



    }
}
