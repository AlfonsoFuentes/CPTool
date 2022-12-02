


using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.ElectricalBoxs
{
    internal class AddEditElectricalBoxHandler : CommandHandler<EditElectricalBox, AddElectricalBox, ElectricalBox>, IRequestHandler<Command<EditElectricalBox>, IResult>
    {

        public AddEditElectricalBoxHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteElectricalBoxHandler : DeleteCommandHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<DeleteCommand<EditElectricalBox>, IResult>
    {

        public DeleteElectricalBoxHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListElectricalBoxHandler : QueryListHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<QueryList<EditElectricalBox>, List<EditElectricalBox>>
    {

        public GetListElectricalBoxHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdElectricalBoxHandler : QueryIdHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<QueryId<EditElectricalBox>, EditElectricalBox>

    {


        public QueryIdElectricalBoxHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
