namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    internal class EditEquipmentTypeHandler : EditBaseHandler<EditEquipmentType, EquipmentType>, IRequestHandler<EditEquipmentType, Result<int>>
    {


        public EditEquipmentTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditEquipmentType> logger) 
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
