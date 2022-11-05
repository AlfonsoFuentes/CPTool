namespace CPTool.Application.Features.SignalsFeatures.CreateEdit
{
    internal class SignalHandler : AddEditBaseHandler<AddSignal,EditSignal, Signal>, IRequestHandler<EditSignal, Result<int>>
    {


        public SignalHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditSignal> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}