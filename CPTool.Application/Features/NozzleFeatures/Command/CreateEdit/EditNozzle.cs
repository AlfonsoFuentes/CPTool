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
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class EditNozzle : EditCommand, IRequest<Result<int>>
    {
      
        public int? PipeAccesoryId => PipeAccesory?.Id == 0 ? null : PipeAccesory?.Id;
        public EditPipeAccesory? PipeAccesory { get; set; }
        [Report(Order = 3)]
        public string PipeAccesoryName => PipeAccesory==null?"": PipeAccesory!.Name;
        public int Order { get; set; }
        public int? ConnectedToId => ConnectedTo?.Id == 0 ? null : ConnectedTo?.Id;
        public EditMWOItem? ConnectedTo { get; set; } = new();
        [Report(Order = 4)]
        public string ConnectedToName => ConnectedTo == null ? "" : ConnectedTo!.TagId;
   
        public int? EquipmentItemId => EquipmentItem == null || EquipmentItem?.Id == 0  ? null : EquipmentItem?.Id;
        public EditEquipmentItem? EquipmentItem { get; set; } = new();
        public int? InstrumentItemId => InstrumentItem == null || InstrumentItem?.Id == 0  ? null : InstrumentItem?.Id;
        public EditInstrumentItem? InstrumentItem { get; set; } = new();

        public int? PipingItemId => PipingItem==null|| PipingItem?.Id == 0  ? null : PipingItem?.Id;
        public EditPipingItem? PipingItem { get; set; } = new();

        public int? PipeDiameterId => PipeDiameter?.Id == 0  ? null : PipeDiameter?.Id;
        public EditPipeDiameter? PipeDiameter { get; set; } = new();
        [Report(Order = 5)]
        public string PipeDiameterName => PipeDiameter == null ? "" : PipeDiameter!.Name;
       
        public int? ConnectionTypeId => ConnectionType?.Id == 0  ? null : ConnectionType?.Id;
        public EditConnectionType? ConnectionType { get; set; } = new();
        [Report(Order = 6)] public string ConnectionTypeName => ConnectionType == null ? "" : ConnectionType!.Name;
        public int? nGasketId => nGasket?.Id == 0  ? null : nGasket?.Id;
        public EditGasket? nGasket { get; set; } = new();
        [Report(Order = 7)]
        public string GasketName => nGasket == null ? "" : nGasket!.Name;
        public int? nMaterialId => nMaterial?.Id == 0  ? null : nMaterial?.Id;
        public EditMaterial? nMaterial { get; set; } = new();
        [Report(Order = 8)]
        public string MaterialName => nMaterial == null ? "" : nMaterial!.Name;

        [Report(Order = 9)]
        public StreamType StreamType { get; set; }
        public int? nPipeClassId => nPipeClass?.Id == 0  ? null : nPipeClass?.Id;
        public EditPipeClass? nPipeClass { get; set; } = new();
        [Report(Order = 10)]

        public string PipeClassName => nPipeClass == null ? "" : nPipeClass!.Name;
        public string? Description { get; set; } = string.Empty;

    }
}
