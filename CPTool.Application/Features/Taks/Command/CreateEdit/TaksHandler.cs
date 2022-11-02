namespace CPTool.Application.Features.TaksFeatures.CreateEdit
{
    internal class TaksHandler : AddEditBaseHandler<AddTaks,EditTaks, Taks>, IRequestHandler<EditTaks, Result<int>>
    {


        public TaksHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditTaks> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }

}
