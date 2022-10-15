namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    internal class AddMaterialHandler : AddBaseHandler<AddMaterial, Material>, IRequestHandler<AddMaterial, Result<int>>
    {


        public AddMaterialHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddMaterial> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }

    }
}
