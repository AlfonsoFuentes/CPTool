namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    internal class AddEquipmentTypeHandler : AddBaseHandler<AddEquipmentType, EquipmentType>, IRequestHandler<AddEquipmentType, Result<int>>
    {
       

        public AddEquipmentTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEquipmentType> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }

        
    }
}
