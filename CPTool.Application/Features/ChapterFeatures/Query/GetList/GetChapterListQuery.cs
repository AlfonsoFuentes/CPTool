
using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetList
{

    public class GetChapterListQuery : GetListQuery, IRequest<List<AddEditChapterCommand>>
    {



    }
    public class GetUnitdaryBasePrizeListQueryHandler : IRequestHandler<GetChapterListQuery, List<AddEditChapterCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitdaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditChapterCommand>> Handle(GetChapterListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Chapter>().GetAllAsync();

            return _mapper.Map<List<AddEditChapterCommand>>(list);

        }
    }
}
