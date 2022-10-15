namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    internal class EditPipeClassHandler : EditBaseHandler<EditPipeClass, PipeClass>, IRequestHandler<EditPipeClass, Result<int>>
    {


        public EditPipeClassHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPipeClass> logger)
            : base(unitofwork, mapper, emailService, logger) { }



    }
}
