using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetById
{

    public class GetByIdChapterQuery : GetByIdQuery, IRequest<AddChapter>
    {
        public GetByIdChapterQuery() { }
        
    }
    public class GetByIdChapterQueryHandler : IRequestHandler<GetByIdChapterQuery, AddChapter>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdChapterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddChapter> Handle(GetByIdChapterQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Chapter>().GetByIdAsync(request.Id);

            return _mapper.Map<AddChapter>(table);

        }
    }
    
}
