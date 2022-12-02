using CPTool.Application.Features.MWOItemFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.MWOItems
{
    internal class AddEditMWOItemHandler : CommandHandler<EditMWOItem, AddMWOItem, MWOItem>, IRequestHandler<Command<EditMWOItem>, IResult>
    {

        public AddEditMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMWOItemHandler : DeleteCommandHandler<EditMWOItem, MWOItem>, IRequestHandler<DeleteCommand<EditMWOItem>, IResult>
    {

        public DeleteMWOItemHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMWOItemHandler : QueryListHandler<EditMWOItem, MWOItem>, IRequestHandler<QueryList<EditMWOItem>, List<EditMWOItem>>
    {

        public GetListMWOItemHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMWOItem>> Handle(QueryList<EditMWOItem> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWOItem.GetAllAsync();
            list = list.OrderBy(x => x.ChapterId).ToList();

            var retorno = _mapper.Map<List<EditMWOItem>>(list);
            return retorno;

        }
    }
    internal class QueryIdMWOItemHandler : QueryIdHandler<EditMWOItem, MWOItem>, IRequestHandler<QueryId<EditMWOItem>, EditMWOItem>

    {


        public QueryIdMWOItemHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMWOItem> Handle(QueryId<EditMWOItem> request, CancellationToken cancellationToken)
        {
            EditMWOItem result = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.RepositoryMWOItem.GetMWOItemIdAsync(request.Id);

                result = _mapper.Map<EditMWOItem>(table);
            }



            return result;

        }
    }
}
