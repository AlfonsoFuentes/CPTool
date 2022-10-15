namespace CPTool.Application.Features.VendorCodeFeatures.CreateEdit
{
    internal class EditVendorCodeHandler : EditBaseHandler<EditVendorCode, VendorCode>, IRequestHandler<EditVendorCode, Result<int>>
    {


        public EditVendorCodeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditVendorCode> logger)
            : base(unitofwork, mapper, emailService, logger) { }


    }
}
