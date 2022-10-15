namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    internal class EditEquipmentTypeSubHandler : EditBaseHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<EditEquipmentTypeSub, Result<int>>
    {

        public EditEquipmentTypeSubHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditEquipmentTypeSub> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }

}
