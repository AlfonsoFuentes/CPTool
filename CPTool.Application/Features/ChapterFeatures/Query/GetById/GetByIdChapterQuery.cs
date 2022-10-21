using CPTool.Application.Features.Base;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetById
{

    public class GetByIdChapterQuery : GetByIdQuery, IRequest<EditChapter>
    {
        public GetByIdChapterQuery() { }
        
    }
    public class GetByIdChapterQueryHandler : 
        GetByIdQueryHandler<EditChapter, Chapter, GetByIdChapterQuery>, IRequestHandler<GetByIdChapterQuery, EditChapter>
    {


        public GetByIdChapterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {
            {

            }

        }
    }
}
