namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    internal class PipeAccesoryHandler : AddEditBaseHandler<AddPipeAccesory,EditPipeAccesory, PipeAccesory>, IRequestHandler<EditPipeAccesory, Result<int>>
    {


        public PipeAccesoryHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPipeAccesory> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }

}
