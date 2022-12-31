using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate
{
    public class InstrumentItemCommandResponse : BaseResponse
    {
        public InstrumentItemCommandResponse() : base()
        {

        }

        public CommandInstrumentItem? InstrumentItemObject { get; set; }
    }
}