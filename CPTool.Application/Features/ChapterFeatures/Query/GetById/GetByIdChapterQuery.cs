using CPTool.Application.Contracts.Persistence;
using CPTool.Application.Features.Base;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetById
{

    public class GetByIdChapterQuery : GetByIdQuery, IRequest<EditChapter>
    {
        public GetByIdChapterQuery() { }
        
    }
    public class GetByIdChapterQueryHandler : 
        IRequestHandler<GetByIdChapterQuery, EditChapter>
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;

        public GetByIdChapterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) 
        {
            _unitofwork = unitofwork;
            _mapper = mapper;

        }

        public async Task<EditChapter> Handle(GetByIdChapterQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Chapter>().GetByIdAsync(request.Id);

            return _mapper.Map<EditChapter>(table);
        }
    }
}
