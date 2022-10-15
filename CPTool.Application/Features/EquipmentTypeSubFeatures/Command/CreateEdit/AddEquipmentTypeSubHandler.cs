namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    internal class AddEquipmentTypeSubHandler : AddBaseHandler<AddEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<AddEquipmentTypeSub, Result<int>>
    {
        
        public AddEquipmentTypeSubHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEquipmentTypeSub> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }

       
    }

}
