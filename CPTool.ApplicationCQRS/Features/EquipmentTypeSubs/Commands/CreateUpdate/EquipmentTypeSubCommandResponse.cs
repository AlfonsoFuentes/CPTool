using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class EquipmentTypeSubCommandResponse : BaseResponse
    {
        public EquipmentTypeSubCommandResponse() : base()
        {

        }

        public CommandEquipmentTypeSub? EquipmentTypeSubObject { get; set; }
    }
}