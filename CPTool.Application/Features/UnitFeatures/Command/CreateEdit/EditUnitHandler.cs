namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    internal class UnitHandler : AddEditBaseHandler<AddUnit,EditUnit, CPTool.Domain.Entities.Unit>, IRequestHandler<EditUnit, Result<int>>
    {


        public UnitHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditUnit> logger)
            : base(unitofwork, mapper,  logger) { }



    }
}
