
using CPTool.Application.Features.GasketsFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.Gaskets
{
    internal class AddEditGasketHandler : CommandHandler<EditGasket, AddGasket, Gasket>, IRequestHandler<Command<EditGasket>, IResult>
    {

        public AddEditGasketHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteGasketHandler : DeleteCommandHandler<EditGasket, Gasket>, IRequestHandler<DeleteCommand<EditGasket>, IResult>
    {

        public DeleteGasketHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListGasketHandler : QueryListHandler<EditGasket, Gasket>, IRequestHandler<QueryList<EditGasket>, List<EditGasket>>
    {

        public GetListGasketHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdGasketHandler : QueryIdHandler<EditGasket, Gasket>, IRequestHandler<QueryId<EditGasket>, EditGasket>

    {


        public QueryIdGasketHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
