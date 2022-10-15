namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    internal class AddPipeAccesoryHandler :AddBaseHandler<AddPipeAccesory, PipeAccesory>, IRequestHandler<AddPipeAccesory, Result<int>>
    {


        public AddPipeAccesoryHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPipeAccesory> logger)
            :base(unitofwork,mapper,emailService,logger)
        {
           
        }

      
    }

}
