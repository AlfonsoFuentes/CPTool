
using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetList
{

    public class GetChapterListQuery : GetListQuery, IRequest<List<EditChapter>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetChapterListQuery, List<EditChapter>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditChapter>> Handle(GetChapterListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Chapter>().GetAllAsync();

            return _mapper.Map<List<EditChapter>>(list);

        }
    }
}
