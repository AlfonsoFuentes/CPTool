namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    internal class PipeDiameterHandler : AddEditBaseHandler<AddPipeDiameter, EditPipeDiameter, PipeDiameter>, IRequestHandler<EditPipeDiameter, Result<int>>
    {


        public PipeDiameterHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPipeDiameter> logger)
        : base(unitofwork, mapper,  logger) { }


    }

}
