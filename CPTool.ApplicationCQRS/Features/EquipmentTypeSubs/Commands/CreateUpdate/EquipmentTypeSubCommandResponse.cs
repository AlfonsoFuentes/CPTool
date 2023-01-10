using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class EquipmentTypeSubCommandResponse : BaseResponse<CommandEquipmentTypeSub>
    {
        public EquipmentTypeSubCommandResponse() : base()
        {

        }
    }
}