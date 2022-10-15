namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    internal class EditPipeAccesoryHandler : EditBaseHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<EditPipeAccesory, Result<int>>
    {


        public EditPipeAccesoryHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPipeAccesory> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }

}
