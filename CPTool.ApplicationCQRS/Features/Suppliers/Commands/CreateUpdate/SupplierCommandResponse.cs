using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate
{
    public class SupplierCommandResponse : BaseResponse
    {
        public SupplierCommandResponse() : base()
        {

        }

        public CommandSupplier? SupplierObject { get; set; }
    }
}