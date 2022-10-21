namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    internal class EquipmentTypeHandler : 
        AddEditBaseHandler<AddEquipmentType,EditEquipmentType, EquipmentType>, 
        IRequestHandler<EditEquipmentType, Result<int>>
    {


        public EquipmentTypeHandler(IUnitOfWork unitofwork, IMapper mapper,  ILogger<EditEquipmentType> logger)
            : base(unitofwork, mapper,logger)
        {

        }


    }
}
