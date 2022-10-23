using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class EditNozzle : EditCommand, IRequest<Result<int>>
    {
        public int? PipeAccesoryId => PipeAccesory?.Id == 0 ? null : PipeAccesory?.Id;
        public EditPipeAccesory? PipeAccesory { get; set; }
        public int Order { get; set; }
        public int? ConnectedToId => ConnectedTo?.Id == 0 ? null : ConnectedTo?.Id;
        public EditMWOItem? ConnectedTo { get; set; } = new();

        public int? EquipmentItemId => EquipmentItem?.Id == 0  ? null : EquipmentItem?.Id;
        public EditEquipmentItem? EquipmentItem { get; set; } = new();
        public int? InstrumentItemId => InstrumentItem?.Id == 0  ? null : InstrumentItem?.Id;
        public EditInstrumentItem? InstrumentItem { get; set; } = new();

        public int? PipingItemId => PipingItem?.Id == 0  ? null : PipingItem?.Id;
        public EditPipingItem? PipingItem { get; set; } = new();

        public int? PipeDiameterId => PipeDiameter?.Id == 0  ? null : PipeDiameter?.Id;
        public EditPipeDiameter? PipeDiameter { get; set; } = new();
        public int? ConnectionTypeId => ConnectionType?.Id == 0  ? null : ConnectionType?.Id;
        public EditConnectionType? ConnectionType { get; set; } = new();
        public int? nGasketId => nGasket?.Id == 0  ? null : nGasket?.Id;
        public EditGasket? nGasket { get; set; } = new();
        public int? nMaterialId => nMaterial?.Id == 0  ? null : nMaterial?.Id;
        public EditMaterial? nMaterial { get; set; } = new();

        public StreamType StreamType { get; set; }
        public int? nPipeClassId => nPipeClass?.Id == 0  ? null : nPipeClass?.Id;
        public EditPipeClass? nPipeClass { get; set; } = new();

      

    }
}
