namespace CPTool.Application.Features.VendorCodeFeatures.CreateEdit
{
    internal class AddVendorCodeHandler : AddBaseHandler<AddVendorCode, VendorCode>, IRequestHandler<AddVendorCode, Result<int>>
    {


        public AddVendorCodeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddVendorCode> logger)
            : base(unitofwork, mapper, emailService, logger) { }


    }
}
