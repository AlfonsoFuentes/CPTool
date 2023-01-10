using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate
{
    public class TaxCodeLDCommandResponse : BaseResponse<CommandTaxCodeLD>
    {
        public TaxCodeLDCommandResponse() : base()
        {

        }
    }
}