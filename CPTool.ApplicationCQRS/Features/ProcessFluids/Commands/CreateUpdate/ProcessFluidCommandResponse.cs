using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate
{
    public class ProcessFluidCommandResponse : BaseResponse
    {
        public ProcessFluidCommandResponse() : base()
        {

        }

        public CommandProcessFluid? ProcessFluidObject { get; set; }
    }
}