
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;

namespace CPTool.ApplicationRadzen.Features.FieldLocations
{
    internal class AddEditFieldLocationHandler : CommandHandler<EditFieldLocation, AddFieldLocation, FieldLocation>, IRequestHandler<Command<EditFieldLocation>, IResult>
    {

        public AddEditFieldLocationHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteFieldLocationHandler : DeleteCommandHandler<EditFieldLocation, FieldLocation>, IRequestHandler<DeleteCommand<EditFieldLocation>, IResult>
    {

        public DeleteFieldLocationHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListFieldLocationHandler : QueryListHandler<EditFieldLocation, FieldLocation>, IRequestHandler<QueryList<EditFieldLocation>, List<EditFieldLocation>>
    {

        public GetListFieldLocationHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdFieldLocationHandler : QueryIdHandler<EditFieldLocation, FieldLocation>, IRequestHandler<QueryId<EditFieldLocation>, EditFieldLocation>

    {


        public QueryIdFieldLocationHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
