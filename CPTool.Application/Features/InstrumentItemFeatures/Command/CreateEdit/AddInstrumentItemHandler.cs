namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    internal class AddInstrumentItemHandler :AddBaseHandler<AddInstrumentItem, InstrumentItem>, IRequestHandler<AddInstrumentItem, Result<int>>
    {
      

        public AddInstrumentItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddInstrumentItem> logger) 
            : base(unitofwork, mapper, emailService, logger)
        {

        }

        
        }

}
