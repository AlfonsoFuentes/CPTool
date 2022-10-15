namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    internal class EditMaterialHandler : EditBaseHandler<EditMaterial, Material>, IRequestHandler<EditMaterial, Result<int>>
    {


        public EditMaterialHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditMaterial> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }

    }
}
