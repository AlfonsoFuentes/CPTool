namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit
{
    internal class AddUnitaryBasePrizeHandler :AddBaseHandler<AddUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<AddUnitaryBasePrize, Result<int>>
    {
       

        public AddUnitaryBasePrizeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddUnitaryBasePrize> logger)
            :base(unitofwork,mapper,emailService,logger)
        {
           
        }

       
    }
}
