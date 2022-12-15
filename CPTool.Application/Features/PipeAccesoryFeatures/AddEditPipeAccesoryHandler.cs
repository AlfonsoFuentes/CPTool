using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;


namespace CPTool.Application.Features.PipeAccesoryFeatures
{
    internal class AddEditPipeAccesoryHandler : CommandHandler<EditPipeAccesory, AddPipeAccesory, PipeAccesory>, IRequestHandler<EditPipeAccesory, Result<int>>
    {

        public AddEditPipeAccesoryHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePipeAccesoryHandler : DeleteCommandHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<DeleteCommand<EditPipeAccesory>, IResult>
    {

        public DeletePipeAccesoryHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPipeAccesoryHandler : QueryListHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<QueryList<EditPipeAccesory>, List<EditPipeAccesory>>
    {

        public GetListPipeAccesoryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditPipeAccesory>> Handle(QueryList<EditPipeAccesory> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPipeAccesory.GetAllAsync();

            return _mapper.Map<List<EditPipeAccesory>>(list);

        }
    }
    internal class QueryIdPipeAccesoryHandler : QueryIdHandler<EditPipeAccesory, PipeAccesory>, IRequestHandler<QueryId<EditPipeAccesory>, EditPipeAccesory>

    {


        public QueryIdPipeAccesoryHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPipeAccesory> Handle(QueryId<EditPipeAccesory> request, CancellationToken cancellationToken)
        {
            EditPipeAccesory result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPipeAccesory.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPipeAccesory>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPipeAccesoryHandler : QueryExcelHandler<EditPipeAccesory>, IRequestHandler<QueryExcel<EditPipeAccesory>, QueryExcel<EditPipeAccesory>>

    {


        public QueryExcelPipeAccesoryHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
