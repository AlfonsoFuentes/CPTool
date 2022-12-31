using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class CommandEquipmentTypeSub : CommandBase, IRequest<EquipmentTypeSubCommandResponse>
    {


        public string TagLetter { get; set; } = string.Empty;

        public int? EquipmentTypeId => EquipmentType == null ? null : EquipmentType?.Id;
        public CommandEquipmentType? EquipmentType { get; set; }
      
        public string EquipmentTypeName => EquipmentType!.Name;

    }

}
