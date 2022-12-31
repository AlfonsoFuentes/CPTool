using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate
{
    public class CommandEquipmentType : CommandBase, IRequest<EquipmentTypeCommandResponse>
    {


        public string TagLetter { get; set; } = string.Empty;


        //public List<CommandEquipmentTypeSub>? EquipmentTypeSubs { get; set; } = new();

    }

}
