namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    internal class EditDownPaymentHandler : EditBaseHandler<EditDownPayment, DownPayment>, IRequestHandler<EditDownPayment, Result<int>>
    {


        public EditDownPaymentHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditDownPayment> logger) 
            : base(unitofwork, mapper, emailService, logger)
        {

        }

    }
}
