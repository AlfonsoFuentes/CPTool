namespace CPTool.Application.Features.EquipmentItemFeatures.CreateEdit
{
    internal class EquipmentItemHandler : AddEditBaseHandler<AddEquipmentItem, EditEquipmentItem, EquipmentItem>, 
        IRequestHandler<EditEquipmentItem, Result<int>>
    {


        public EquipmentItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditEquipmentItem> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
