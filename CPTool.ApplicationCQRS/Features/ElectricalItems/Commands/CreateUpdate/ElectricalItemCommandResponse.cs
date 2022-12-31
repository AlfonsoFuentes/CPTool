using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate
{
    public class ElectricalItemCommandResponse : BaseResponse
    {
        public ElectricalItemCommandResponse() : base()
        {

        }

        public CommandElectricalItem? ElectricalItemObject { get; set; }
    }
}