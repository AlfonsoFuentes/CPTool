namespace CPTool.Application.Generic
{
    public class CommandReset : IRequest<IResult>
    {

    }
    public class CommandResetHandler : IRequestHandler<CommandReset, IResult>
    {
        protected IUnitOfWork _unitOfWork;

        public CommandResetHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(CommandReset request, CancellationToken cancellationToken)
        {
            _unitOfWork.Reset();
            return await Result.SuccessAsync($"Tracker fully reseted");
        }
    }
}
