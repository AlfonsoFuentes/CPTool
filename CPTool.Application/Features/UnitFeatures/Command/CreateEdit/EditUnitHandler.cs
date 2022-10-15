namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    internal class EditUnitHandler : EditBaseHandler<EditUnit, CPTool.Domain.Entities.Unit>, IRequestHandler<EditUnit, Result<int>>
    {


        public EditUnitHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditUnit> logger)
            : base(unitofwork, mapper, emailService, logger) { }



    }
}
