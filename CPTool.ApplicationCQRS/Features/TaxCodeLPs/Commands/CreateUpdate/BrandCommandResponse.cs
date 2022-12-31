using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate
{
    public class TaxCodeLPCommandResponse : BaseResponse
    {
        public TaxCodeLPCommandResponse() : base()
        {

        }

        public CommandTaxCodeLP? TaxCodeLPObject { get; set; }
    }
}