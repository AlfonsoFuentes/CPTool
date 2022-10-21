namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    internal class EquipmentTypeSubHandler : AddEditBaseHandler<AddEquipmentTypeSub,EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<EditEquipmentTypeSub, Result<int>>
    {

        public EquipmentTypeSubHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditEquipmentTypeSub> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }

}
