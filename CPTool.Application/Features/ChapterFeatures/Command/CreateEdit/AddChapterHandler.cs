namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    internal class AddChapterHandler :AddBaseHandler<AddChapter, Chapter>, IRequestHandler<AddChapter, Result<int>>
    {
      
        public AddChapterHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddChapter> logger) : base(unitofwork, mapper, emailService, logger)
        {
           
        }

       
    }
}
