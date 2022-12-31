using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate
{
    public class ElectricalBoxCommandResponse : BaseResponse
    {
        public ElectricalBoxCommandResponse() : base()
        {

        }

        public CommandElectricalBox? ElectricalBoxObject { get; set; }
    }
}