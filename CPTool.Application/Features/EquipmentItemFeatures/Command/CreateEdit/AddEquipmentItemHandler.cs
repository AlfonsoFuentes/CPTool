namespace CPTool.Application.Features.EquipmentItemFeatures.CreateEdit
{
    internal class AddEquipmentItemHandler : AddBaseHandler<AddEquipmentItem, EquipmentItem>, IRequestHandler<AddEquipmentItem, Result<int>>
    {
      

        public AddEquipmentItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEquipmentItem> logger)
            : base(unitofwork, mapper, emailService, logger)
        {
           
        }

        
    }
}
