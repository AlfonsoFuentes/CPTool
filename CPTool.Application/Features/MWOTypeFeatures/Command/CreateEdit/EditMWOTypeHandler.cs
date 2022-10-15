namespace CPTool.Application.Features.MMOTypeFeatures.CreateEdit
{
    internal class EditMWOTypeHandler : EditBaseHandler<EditMWOType, MWOType>, IRequestHandler<EditMWOType, Result<int>>
    {

        public EditMWOTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditMWOType> logger) :
            base(unitofwork, mapper, emailService, logger)
        { }



    }

}
