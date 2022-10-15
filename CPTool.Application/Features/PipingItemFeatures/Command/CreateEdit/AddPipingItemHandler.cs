namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    internal class AddPipingItemHandler :AddBaseHandler<AddPipingItem, PipingItem>, IRequestHandler<AddPipingItem, Result<int>>
    {
       
        public AddPipingItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPipingItem> logger)
        :base(unitofwork, mapper, emailService, logger)
        {

        }

       
    }
}
