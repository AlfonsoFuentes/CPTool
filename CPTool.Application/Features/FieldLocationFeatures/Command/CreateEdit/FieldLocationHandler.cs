namespace CPTool.Application.Features.FieldLocationsFeatures.CreateEdit
{
    internal class FieldLocationHandler : AddEditBaseHandler<AddFieldLocation,EditFieldLocation, FieldLocation>, IRequestHandler<EditFieldLocation, Result<int>>
    {


        public FieldLocationHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditFieldLocation> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}