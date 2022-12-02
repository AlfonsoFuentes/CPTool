using CPTool.Application.Features.UnitFeatures.CreateEdit;
using Unit = CPTool.Domain.Entities.Unit;

namespace CPTool.ApplicationRadzen.Features.Units
{
    internal class AddEditUnitHandler : CommandHandler<EditUnit, AddUnit, Unit>, IRequestHandler<Command<EditUnit>, IResult>
    {

        public AddEditUnitHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUnitHandler : DeleteCommandHandler<EditUnit, Unit>, IRequestHandler<DeleteCommand<EditUnit>, IResult>
    {

        public DeleteUnitHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUnitHandler : QueryListHandler<EditUnit, Unit>, IRequestHandler<QueryList<EditUnit>, List<EditUnit>>
    {

        public GetListUnitHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdUnitHandler : QueryIdHandler<EditUnit, Unit>, IRequestHandler<QueryId<EditUnit>, EditUnit>

    {


        public QueryIdUnitHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
