namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    internal class EditInstrumentItemHandler : EditBaseHandler<EditInstrumentItem, InstrumentItem>, IRequestHandler<EditInstrumentItem, Result<int>>
    {


        public EditInstrumentItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditInstrumentItem> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }

}
