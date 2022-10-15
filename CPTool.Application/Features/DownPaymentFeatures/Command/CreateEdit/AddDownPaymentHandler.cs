namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    internal class AddDownPaymentHandler :AddBaseHandler<AddDownPayment, DownPayment>, IRequestHandler<AddDownPayment, Result<int>>
    {


        public AddDownPaymentHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddDownPayment> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }

    }
}
