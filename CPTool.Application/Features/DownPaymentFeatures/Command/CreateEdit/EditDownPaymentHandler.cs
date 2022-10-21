namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    internal class DownPaymentHandler : AddEditBaseHandler<AddDownPayment,EditDownPayment, DownPayment>, IRequestHandler<EditDownPayment, Result<int>>
    {


        public DownPaymentHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditDownPayment> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }

    }
}
