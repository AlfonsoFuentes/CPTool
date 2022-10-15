namespace CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit
{
    internal class EditConnectionTypeHandler : EditBaseHandler<EditConnectionType, ConnectionType>, IRequestHandler<EditConnectionType, Result<int>>
    {


        public EditConnectionTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditConnectionType> logger)
             : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
