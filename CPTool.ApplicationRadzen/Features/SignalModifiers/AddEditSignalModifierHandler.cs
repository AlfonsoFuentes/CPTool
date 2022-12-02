
using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.SignalModifiers
{
    internal class AddEditSignalModifierHandler : CommandHandler<EditSignalModifier, AddSignalModifier, SignalModifier>, IRequestHandler<Command<EditSignalModifier>, IResult>
    {

        public AddEditSignalModifierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalModifierHandler : DeleteCommandHandler<EditSignalModifier, SignalModifier>, IRequestHandler<DeleteCommand<EditSignalModifier>, IResult>
    {

        public DeleteSignalModifierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalModifierHandler : QueryListHandler<EditSignalModifier, SignalModifier>, IRequestHandler<QueryList<EditSignalModifier>, List<EditSignalModifier>>
    {

        public GetListSignalModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdSignalModifierHandler : QueryIdHandler<EditSignalModifier, SignalModifier>, IRequestHandler<QueryId<EditSignalModifier>, EditSignalModifier>

    {


        public QueryIdSignalModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
