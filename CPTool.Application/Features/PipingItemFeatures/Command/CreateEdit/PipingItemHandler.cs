namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    internal class PipingItemHandler : AddEditBaseHandler<AddPipingItem, EditPipingItem, PipingItem>, IRequestHandler<EditPipingItem, Result<int>>
    {

        public PipingItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPipingItem> logger)
        : base(unitofwork, mapper,  logger)
        {

        }


    }
}
