namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    internal class ChapterHandler : AddEditBaseHandler<AddChapter, EditChapter, Chapter>, IRequestHandler<EditChapter, Result<int>>
    {

        public ChapterHandler(IUnitOfWork unitofwork, IMapper mapper,ILogger<EditChapter> logger) 
            : base(unitofwork, mapper, logger)
        {

        }


    }
}
