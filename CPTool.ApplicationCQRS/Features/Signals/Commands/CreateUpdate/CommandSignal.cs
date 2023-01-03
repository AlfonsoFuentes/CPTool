using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate
{
    public class CommandSignal : CommandBase, IRequest<SignalCommandResponse>
    {


      
        public bool IsWired { get; set; }
        public int? SignalTypeId => SignalType?.Id == 0 ? null : SignalType?.Id;
        public CommandSignalType? SignalType { get; set; } = new();
        
        public string SignalTypeName => SignalType==null?"":SignalType!.Name;
       
        public string IOTypeName => IOType.ToString();
        public IOType IOType { get; set; }

        public int? WireId => Wire!.Id == 0 ? null : Wire?.Id;
        public CommandWire? Wire { get; set; } = new();
        
        public string WireName => Wire == null ? "" : Wire!.Name;
        public int? FieldLocationId => FieldLocation!.Id == 0 ? null : FieldLocation?.Id;
        public CommandFieldLocation? FieldLocation { get; set; } = new();
        
        public string FieldLocationName => FieldLocation == null ? "" : FieldLocation!.Name;
        public int? ElectricalBoxId => ElectricalBox!.Id == 0 ? null : ElectricalBox?.Id;
        public CommandElectricalBox? ElectricalBox { get; set; } = new();
        
        public string ElectricalBoxName => ElectricalBox == null ? "" : ElectricalBox!.Name;
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public CommandMWOItem? MWOItem { get; set; } = new();
        
        public string MWOItemName => MWOItem == null ? "" : MWOItem!.Name;
        
        public string MWOItemTagId => MWOItem == null ? "" : MWOItem!.TagId;
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        public CommandMWO? MWO { get; set; } = new();
        
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public int? SignalModifierId => SignalModifier == null ? null : SignalModifier?.Id;
        public CommandSignalModifier? SignalModifier { get; set; } = new();
    
        public string SignalModifierName => SignalModifier == null ? "" : SignalModifier!.Name;
        public bool Disconect { get; set; }
        
        public bool InstrumentAir { get; set; }
        
        public bool FrequencyInverter { get; set; }
        public List<CommandControlLoop>? ProcessVariables { get; set; } = new();
        public List<CommandControlLoop>? ControlledVariables { get; set; } = new();
        public override string Name { get => GetName(); set => base.Name = value; }
        string GetName()
        {
            if (MWOItem == null) return "";
            if (MWOItem.TagId == "") return "";
            if (SignalModifier == null) return MWOItem.TagId;
            return $"{MWOItem.TagId}.{SignalModifier.Name}";
        }

    }

}
