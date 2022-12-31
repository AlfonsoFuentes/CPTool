using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate
{
    public class EquipmentTypeCommandResponse : BaseResponse
    {
        public EquipmentTypeCommandResponse() : base()
        {

        }

        public CommandEquipmentType? EquipmentTypeObject { get; set; }
    }
}