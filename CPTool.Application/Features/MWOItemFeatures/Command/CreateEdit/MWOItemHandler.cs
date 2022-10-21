namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    internal class MWOItemHandler : AddEditBaseHandler<AddMWOItem,EditMWOItem, MWOItem>, IRequestHandler<EditMWOItem, Result<int>>
    {


        public MWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditMWOItem> logger)
            : base(unitofwork, mapper,  logger) { }
    }
}
