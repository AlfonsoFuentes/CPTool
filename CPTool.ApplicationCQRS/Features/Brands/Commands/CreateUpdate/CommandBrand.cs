using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate
{
    public class CommandBrand : CommandBase, IRequest<BrandCommandResponse>
    {


        public List<CommandBrandSupplier>? BrandSuppliers { get; set; } = new();

        public string BrandTypeName => BrandType.ToString();
        public BrandType BrandType { get; set; }


        public int BrandOriginalId { get; set; }

    }

}
