using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{
    public class EditBrand :EditCommand, IRequest<Result<int>>
    {
        
        public List<EditBrandSupplier>? BrandSuppliers { get; set; }
        public BrandType BrandType { get; set; }

       


    }
}
