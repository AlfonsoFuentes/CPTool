namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    internal class NozzleHandler : AddEditBaseHandler<AddNozzle,EditNozzle, Nozzle>, IRequestHandler<EditNozzle, Result<int>>
    {

        public NozzleHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditNozzle> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
