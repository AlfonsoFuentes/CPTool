using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Domain.Entities;


namespace CPTool.ApplicationRadzen.Features.MWOTypes
{
    internal class AddEditMWOTypeHandler : CommandHandler<EditMWOType, AddMWOType, MWOType>, IRequestHandler<Command<EditMWOType>, IResult>
    {

        public AddEditMWOTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMWOTypeHandler : DeleteCommandHandler<EditMWOType, MWOType>, IRequestHandler<DeleteCommand<EditMWOType>, IResult>
    {

        public DeleteMWOTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMWOTypeHandler : QueryListHandler<EditMWOType, MWOType>, IRequestHandler<QueryList<EditMWOType>, List<EditMWOType>>
    {

        public GetListMWOTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdMWOTypeHandler : QueryIdHandler<EditMWOType, MWOType>, IRequestHandler<QueryId<EditMWOType>, EditMWOType>

    {


        public QueryIdMWOTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
