using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate
{
    public class CommandBrandSupplier : CommandBase, IRequest<BrandSupplierCommandResponse>
    {

        public int SupplierOriginalId { get; set; }
        public int BrandOriginalId { get; set; }
        public int BrandId => Brand == null ? 0 : Brand!.Id;
        public CommandBrand? Brand { get; set; } = new();

        public int SupplierId => Supplier == null ? 0 : Supplier!.Id;
        public CommandSupplier? Supplier { get; set; } = new();


        public void SetOriginalId()
        {
           
            BrandOriginalId = Brand!.Id;
            SupplierOriginalId = Supplier!.Id;
        }


    }

}
