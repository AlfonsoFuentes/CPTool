
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

using CPTool.Domain.Enums;

namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{
    public class EditBrand : EditCommand, IRequest<Result<int>>
    {

        public List<EditBrandSupplier>? BrandSuppliers { get; set; } = new();
        [Report(Order = 3)]
        public string BrandTypeName=> BrandType.ToString();
        public BrandType BrandType { get; set; }

       
        public int BrandOriginalId { get; set; }

    }
}
