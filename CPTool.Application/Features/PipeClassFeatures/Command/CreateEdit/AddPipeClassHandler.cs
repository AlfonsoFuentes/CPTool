namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    internal class AddPipeClassHandler :AddBaseHandler<AddPipeClass, PipeClass>, IRequestHandler<AddPipeClass, Result<int>>
    {
       

        public AddPipeClassHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPipeClass> logger)
            :base(unitofwork, mapper, emailService, logger) { }
        

       
    }
}
