using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.EquipmentTypeSubs
{
    internal class AddEditEquipmentTypeSubHandler : CommandHandler<EditEquipmentTypeSub, AddEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<Command<EditEquipmentTypeSub>, IResult>
    {

        public AddEditEquipmentTypeSubHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteEquipmentTypeSubHandler : DeleteCommandHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<DeleteCommand<EditEquipmentTypeSub>, IResult>
    {

        public DeleteEquipmentTypeSubHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListEquipmentTypeSubHandler : QueryListHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<QueryList<EditEquipmentTypeSub>, List<EditEquipmentTypeSub>>
    {

        public GetListEquipmentTypeSubHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdEquipmentTypeSubHandler : QueryIdHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<QueryId<EditEquipmentTypeSub>, EditEquipmentTypeSub>

    {


        public QueryIdEquipmentTypeSubHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
