namespace CPTool.Application.Features.EquipmentItemFeatures.CreateEdit
{
    internal class EditEquipmentItemHandler : EditBaseHandler<EditEquipmentItem, EquipmentItem>, IRequestHandler<EditEquipmentItem, Result<int>>
    {


        public EditEquipmentItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditEquipmentItem> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
