namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit
{
    internal class EditUnitaryBasePrizeHandler : EditBaseHandler<EditUnitaryBasePrize, UnitaryBasePrize>, IRequestHandler<EditUnitaryBasePrize, Result<int>>
    {


        public EditUnitaryBasePrizeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditUnitaryBasePrize> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
