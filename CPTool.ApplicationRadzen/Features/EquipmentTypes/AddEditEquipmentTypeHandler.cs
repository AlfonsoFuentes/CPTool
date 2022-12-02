using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.EquipmentTypes
{
    internal class AddEditEquipmentTypeHandler : CommandHandler<EditEquipmentType, AddEquipmentType, EquipmentType>, IRequestHandler<Command<EditEquipmentType>, IResult>
    {

        public AddEditEquipmentTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteEquipmentTypeHandler : DeleteCommandHandler<EditEquipmentType, EquipmentType>, IRequestHandler<DeleteCommand<EditEquipmentType>, IResult>
    {

        public DeleteEquipmentTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListEquipmentTypeHandler : QueryListHandler<EditEquipmentType, EquipmentType>, IRequestHandler<QueryList<EditEquipmentType>, List<EditEquipmentType>>
    {

        public GetListEquipmentTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdEquipmentTypeHandler : QueryIdHandler<EditEquipmentType, EquipmentType>, IRequestHandler<QueryId<EditEquipmentType>, EditEquipmentType>

    {


        public QueryIdEquipmentTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
