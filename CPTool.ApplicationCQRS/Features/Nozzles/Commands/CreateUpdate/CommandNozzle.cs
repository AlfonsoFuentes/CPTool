using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate
{
    public class CommandNozzle : CommandBase, IRequest<NozzleCommandResponse>
    {
        public int? PipeAccesoryId => PipeAccesory?.Id == 0 ? null : PipeAccesory?.Id;
        public CommandPipeAccesory? PipeAccesory { get; set; }
       
        public string PipeAccesoryName => PipeAccesory == null ? "" : PipeAccesory!.Name;
        public int Order { get; set; }
        public int? ConnectedToId => ConnectedTo?.Id == 0 ? null : ConnectedTo?.Id;
        public CommandMWOItem? ConnectedTo { get; set; } = new();
       
        public string ConnectedToName => ConnectedTo == null ? "" : ConnectedTo!.TagId;

        public int? EquipmentItemId => EquipmentItem == null || EquipmentItem?.Id == 0 ? null : EquipmentItem?.Id;
        public CommandEquipmentItem? EquipmentItem { get; set; } = new();
        public int? InstrumentItemId => InstrumentItem == null || InstrumentItem?.Id == 0 ? null : InstrumentItem?.Id;
        public CommandInstrumentItem? InstrumentItem { get; set; } = new();

        public int? PipingItemId => PipingItem == null || PipingItem?.Id == 0 ? null : PipingItem?.Id;
        public CommandPipingItem? PipingItem { get; set; } = new();

        public int? PipeDiameterId => PipeDiameter?.Id == 0 ? null : PipeDiameter?.Id;
        public CommandPipeDiameter? PipeDiameter { get; set; } = new();
      
        public string PipeDiameterName => PipeDiameter == null ? "" : PipeDiameter!.Name;

        public int? ConnectionTypeId => ConnectionType?.Id == 0 ? null : ConnectionType?.Id;
        public CommandConnectionType? ConnectionType { get; set; } = new();
       public string ConnectionTypeName => ConnectionType == null ? "" : ConnectionType!.Name;
        public int? nGasketId => nGasket?.Id == 0 ? null : nGasket?.Id;
        public CommandGasket? nGasket { get; set; } = new();
    
        public string GasketName => nGasket == null ? "" : nGasket!.Name;
        public int? nMaterialId => nMaterial?.Id == 0 ? null : nMaterial?.Id;
        public CommandMaterial? nMaterial { get; set; } = new();
   
        public string MaterialName => nMaterial == null ? "" : nMaterial!.Name;

        public StreamType StreamType { get; set; }
        public int? nPipeClassId => nPipeClass?.Id == 0 ? null : nPipeClass?.Id;
        public CommandPipeClass? nPipeClass { get; set; } = new();
        

        public string PipeClassName => nPipeClass == null ? "" : nPipeClass!.Name;
        public string? Description { get; set; } = string.Empty;

        public string? NameDescription => $"{Name} - {Description}";

    }

}
