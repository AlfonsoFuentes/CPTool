using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate
{
    public class BrandCommandResponse : BaseResponse
    {
        public BrandCommandResponse() : base()
        {

        }

        public CommandBrand? BrandObject { get; set; }
    }
}