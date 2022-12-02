
using CPTool.Application.Features.SignalsFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.Signals
{
    internal class AddEditSignalHandler : CommandHandler<EditSignal, AddSignal, Signal>, IRequestHandler<Command<EditSignal>, IResult>
    {

        public AddEditSignalHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalHandler : DeleteCommandHandler<EditSignal, Signal>, IRequestHandler<DeleteCommand<EditSignal>, IResult>
    {

        public DeleteSignalHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalHandler : QueryListHandler<EditSignal, Signal>, IRequestHandler<QueryList<EditSignal>, List<EditSignal>>
    {

        public GetListSignalHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdSignalHandler : QueryIdHandler<EditSignal, Signal>, IRequestHandler<QueryId<EditSignal>, EditSignal>

    {


        public QueryIdSignalHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
