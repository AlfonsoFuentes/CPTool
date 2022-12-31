using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate
{
    public class TaxesItemCommandResponse : BaseResponse
    {
        public TaxesItemCommandResponse() : base()
        {

        }

        public CommandTaxesItem? TaxesItemObject { get; set; }
    }
}