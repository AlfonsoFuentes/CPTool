namespace CPTool.Application.Features.SignalTypesFeatures.CreateEdit
{
    internal class SignalTypeHandler : AddEditBaseHandler<AddSignalType,EditSignalType, SignalType>, IRequestHandler<EditSignalType, Result<int>>
    {


        public SignalTypeHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditSignalType> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}