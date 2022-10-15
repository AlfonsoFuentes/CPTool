namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    internal class EditProcessFluidHandler : EditBaseHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<EditProcessFluid, Result<int>>
    {

        public EditProcessFluidHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditProcessFluid> logger)
            : base(unitofwork, mapper, emailService, logger) { }


    }
}
