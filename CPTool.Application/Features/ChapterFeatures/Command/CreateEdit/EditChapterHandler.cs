namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    internal class EditChapterHandler : EditBaseHandler<EditChapter, Chapter>, IRequestHandler<EditChapter, Result<int>>
    {

        public EditChapterHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditChapter> logger) 
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
