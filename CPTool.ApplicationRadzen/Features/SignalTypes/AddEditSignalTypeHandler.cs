
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.SignalTypes
{
    internal class AddEditSignalTypeHandler : CommandHandler<EditSignalType, AddSignalType, SignalType>, IRequestHandler<Command<EditSignalType>, IResult>
    {

        public AddEditSignalTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalTypeHandler : DeleteCommandHandler<EditSignalType, SignalType>, IRequestHandler<DeleteCommand<EditSignalType>, IResult>
    {

        public DeleteSignalTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalTypeHandler : QueryListHandler<EditSignalType, SignalType>, IRequestHandler<QueryList<EditSignalType>, List<EditSignalType>>
    {

        public GetListSignalTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdSignalTypeHandler : QueryIdHandler<EditSignalType, SignalType>, IRequestHandler<QueryId<EditSignalType>, EditSignalType>

    {


        public QueryIdSignalTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
