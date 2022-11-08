namespace CPTool.Application.Features.ControlLoopFeatures.CreateEdit
{
    internal class ControlLoopHandler : AddEditBaseHandler<AddControlLoop,EditControlLoop, ControlLoop>, IRequestHandler<EditControlLoop, Result<int>>
    {

        public ControlLoopHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditControlLoop> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
