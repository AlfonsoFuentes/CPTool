

using CPTool.Application.Contracts.Persistence;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{

    public class AddBrand :AddCommand, IRequest<Result<int>>
    {
     
        public BrandType BrandType { get; set; }




    }
}
