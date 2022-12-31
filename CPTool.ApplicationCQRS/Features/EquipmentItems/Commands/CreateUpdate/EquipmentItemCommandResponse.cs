using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class EquipmentItemCommandResponse : BaseResponse
    {
        public EquipmentItemCommandResponse() : base()
        {

        }

        public CommandEquipmentItem? EquipmentItemObject { get; set; }
    }
}