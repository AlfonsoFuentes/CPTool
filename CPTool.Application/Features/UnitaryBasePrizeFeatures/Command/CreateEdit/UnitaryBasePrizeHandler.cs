namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit
{
    internal class UnitaryBasePrizeHandler : AddEditBaseHandler<AddUnitaryBasePrize,EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<EditUnitaryBasePrize, Result<int>>
    {


        public UnitaryBasePrizeHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditUnitaryBasePrize> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
