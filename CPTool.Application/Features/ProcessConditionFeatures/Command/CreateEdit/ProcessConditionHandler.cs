namespace CPTool.Application.Features.ProcessConditionFeatures.CreateEdit
{
    internal class ProcessConditionHandler : AddEditBaseHandler<AddProcessCondition, EditProcessCondition, ProcessCondition>, IRequestHandler<EditProcessCondition, Result<int>>
    {


        public ProcessConditionHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditProcessCondition> logger)
            : base(unitofwork, mapper,  logger) { }


    }
}
