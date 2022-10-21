namespace CPTool.Application.Features.VendorCodeFeatures.CreateEdit
{
    internal class VendorCodeHandler : AddEditBaseHandler<AddVendorCode,EditVendorCode, VendorCode>, IRequestHandler<EditVendorCode, Result<int>>
    {


        public VendorCodeHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditVendorCode> logger)
            : base(unitofwork, mapper,  logger) { }


    }
}
