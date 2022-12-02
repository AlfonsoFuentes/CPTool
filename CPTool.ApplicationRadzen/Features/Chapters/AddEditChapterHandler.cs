using CPTool.Application.Features.ChapterFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Chapters
{
    internal class AddEditChapterHandler : CommandHandler<EditChapter, AddChapter, Chapter>, IRequestHandler<Command<EditChapter>, IResult>
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

    }
    internal class QueryIdChapterHandler : QueryIdHandler<EditChapter, Chapter>, IRequestHandler<QueryId<EditChapter>, EditChapter>

    {


        public QueryIdChapterHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
