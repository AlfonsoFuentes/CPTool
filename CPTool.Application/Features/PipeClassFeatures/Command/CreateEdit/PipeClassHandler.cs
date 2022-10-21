namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    internal class PipeClassHandler : AddEditBaseHandler<AddPipeClass,EditPipeClass, PipeClass>, IRequestHandler<EditPipeClass, Result<int>>
    {


        public PipeClassHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPipeClass> logger)
            : base(unitofwork, mapper,  logger) { }



    }
}
