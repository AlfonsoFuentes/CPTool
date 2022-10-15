using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class EditNozzle : EditCommand, IRequest<Result<int>>
    {
        //public int? PipeAccesoryId => PipeAccesoryCommand?.Id == 0 ? null : PipeAccesoryCommand?.Id;
        public EditPipeAccesory? PipeAccesory { get; set; } = new();
        public int Order { get; set; }
        public List<EditPipingItem>? StartPipingItems { get; set; } = new();

        public List<EditPipingItem>? FinishPipingItems { get; set; } = new();

        //public int? EquipmentItemId => EquipmentItemCommand?.Id == 0 ? null : EquipmentItemCommand?.Id;
        public EditEquipmentItem? EquipmentItem { get; set; } 
        //public int? InstrumentItemId => InstrumentItemCommand?.Id == 0 ? null : InstrumentItemCommand?.Id;
        public EditInstrumentItem? InstrumentItem { get; set; }

        //public int? PipingItemId => PipingItemCommand?.Id == 0 ? null : PipingItemCommand?.Id;
        public EditPipingItem? PipingItem { get; set; } 

        //public int? PipeDiameterId => PipeDiameterCommand?.Id == 0 ? null : PipeDiameterCommand?.Id;
        public EditPipeDiameter? PipeDiameter { get; set; } = new();
        //public int? ConnectionTypeId => ConnectionTypeCommand?.Id == 0 ? null : ConnectionTypeCommand?.Id;
        public EditConnectionType? ConnectionType { get; set; } = new();
        //public int? GasketId => GasketCommand?.Id == 0 ? null : GasketCommand?.Id;
        public EditGasket? Gasket { get; set; } = new();
        //public int? MaterialID => MaterialCommand?.Id == 0 ? null : MaterialCommand?.Id;
        public EditMaterial? Material { get; set; } = new();

        public StreamType StreamType { get; set; }



        //public int? PipeClassId => PipeClassCommand?.Id == 0 ? null : PipeClassCommand?.Id;
        public EditPipeClass? PipeClass { get; set; } = new();
        public List<EditNozzle> ParentNozzles { get; set; } = new();
    }
}
