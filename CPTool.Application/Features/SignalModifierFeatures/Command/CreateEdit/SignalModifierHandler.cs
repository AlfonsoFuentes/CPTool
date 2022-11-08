namespace CPTool.Application.Features.SignalModifiersFeatures.CreateEdit
{
    internal class SignalModifierHandler : AddEditBaseHandler<AddSignalModifier,EditSignalModifier, SignalModifier>, IRequestHandler<EditSignalModifier, Result<int>>
    {


        public SignalModifierHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditSignalModifier> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}