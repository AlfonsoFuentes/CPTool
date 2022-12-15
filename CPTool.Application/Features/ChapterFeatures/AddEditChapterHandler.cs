using CPTool.Application.Features.ChapterFeatures.CreateEdit;


namespace CPTool.Application.Features.ChapterFeatures
{
    internal class AddEditChapterHandler : CommandHandler<EditChapter, AddChapter, Chapter>, IRequestHandler<EditChapter, Result<int>>
    {

        public AddEditChapterHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteChapterHandler : DeleteCommandHandler<EditChapter, Chapter>, IRequestHandler<DeleteCommand<EditChapter>, IResult>
    {

        public DeleteChapterHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListChapterHandler : QueryListHandler<EditChapter, Chapter>, IRequestHandler<QueryList<EditChapter>, List<EditChapter>>
    {

        public GetListChapterHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditChapter>> Handle(QueryList<EditChapter> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryChapter.GetAllAsync();

            return _mapper.Map<List<EditChapter>>(list);

        }
    }
    internal class QueryIdChapterHandler : QueryIdHandler<EditChapter, Chapter>, IRequestHandler<QueryId<EditChapter>, EditChapter>

    {


        public QueryIdChapterHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditChapter> Handle(QueryId<EditChapter> request, CancellationToken cancellationToken)
        {
            EditChapter result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryChapter.GetByIdAsync(request.Id);


                result = _mapper.Map<EditChapter>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelChapterHandler : QueryExcelHandler<EditChapter>, IRequestHandler<QueryExcel<EditChapter>, QueryExcel<EditChapter>>

    {


        public QueryExcelChapterHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
