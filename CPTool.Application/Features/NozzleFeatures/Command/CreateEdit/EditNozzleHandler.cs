namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    internal class EditNozzleHandler : EditBaseHandler<EditNozzle, Nozzle>, IRequestHandler<EditNozzle, Result<int>>
    {

        public EditNozzleHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditNozzle> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
