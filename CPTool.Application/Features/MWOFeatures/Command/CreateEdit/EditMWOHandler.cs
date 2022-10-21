namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    internal class MWOHandler : AddEditBaseHandler<AddMWO, EditMWO, MWO>, IRequestHandler<EditMWO, Result<int>>
    {


        public MWOHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditMWO> logger)
            : base(unitofwork, mapper,  logger) { }
    }
}
