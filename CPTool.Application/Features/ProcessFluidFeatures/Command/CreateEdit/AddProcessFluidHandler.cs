namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    internal class AddProcessFluidHandler :AddBaseHandler<AddProcessFluid, ProcessFluid>, IRequestHandler<AddProcessFluid, Result<int>>
    {
       
        public AddProcessFluidHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddProcessFluid> logger)
            :base(unitofwork, mapper, emailService, logger) { }

     
    }
}
