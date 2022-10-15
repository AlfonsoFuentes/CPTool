

using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class AddNozzle : AddCommand, IRequest<Result<int>>
    {
        public int? PipeAccesoryId => PipeAccesoryCommand?.Id == 0? null : PipeAccesoryCommand?.Id;
        public EditPipeAccesory? PipeAccesoryCommand { get; set; } = new(); 
        public int Order { get; set; }
        public List<EditPipingItem>? StartPipingItems { get; set; } = new();

        public List<EditPipingItem>? FinishPipingItems { get; set; } = new();

        public int? EquipmentItemId => EquipmentItemCommand?.Id == 0? null : EquipmentItemCommand?.Id;
        public EditEquipmentItem? EquipmentItemCommand { get; set; } = new(); 
        public int? InstrumentItemId => InstrumentItemCommand?.Id == 0? null : InstrumentItemCommand?.Id;
        public EditInstrumentItem? InstrumentItemCommand { get; set; } = new(); 

        public int? PipingItemId => PipingItemCommand?.Id == 0? null : PipingItemCommand?.Id;
        public EditPipingItem? PipingItemCommand { get; set; } = new(); 

        public int? PipeDiameterId => PipeDiameterCommand?.Id == 0 ? null : PipeDiameterCommand?.Id;
        public EditPipeDiameter? PipeDiameterCommand { get; set; } = new(); 
        public int? ConnectionTypeId => ConnectionTypeCommand?.Id == 0 ?  null : ConnectionTypeCommand?.Id;
        public EditConnectionType? ConnectionTypeCommand { get; set; } = new();
        public int? GasketId => GasketCommand?.Id == 0 ? null : GasketCommand?.Id;
        public EditGasket? GasketCommand { get; set; } = new(); 
        public int? MaterialID => MaterialCommand?.Id == 0 ? null : MaterialCommand?.Id;
        public EditMaterial? MaterialCommand { get; set; } = new();

        public StreamType StreamType { get; set; }

       

        public int? PipeClassId => PipeClassCommand?.Id == 0 ? null : PipeClassCommand?.Id;
        public EditPipeClass? PipeClassCommand { get; set; } = new();
        public List<EditNozzle> ParentNozzles { get; set; } = new();
    }
}
