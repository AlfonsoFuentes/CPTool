
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetList
{

    public class GetChapterListQuery : GetListQuery, IRequest<List<EditChapter>>
    {



    }
    public class GetChapterListQueryHandler :
        GetListQueryHandler<EditChapter, Chapter, GetChapterListQuery>,
        IRequestHandler<GetChapterListQuery, List<EditChapter>>
    {

       
        public GetChapterListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
    }
}
