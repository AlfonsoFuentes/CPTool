using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate
{
    public class BrandSupplierCommandResponse : BaseResponse
    {
        public BrandSupplierCommandResponse() : base()
        {

        }

        public CommandBrandSupplier? BrandSupplierObject { get; set; }
    }
}