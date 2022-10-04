using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Query.GetById
{
    
    public class GetByIdChapterQuery : GetByIdQuery, IRequest<AddEditChapterCommand>
    {
    }
    public class GetByIdChapterQueryHandler : IRequestHandler<GetByIdChapterQuery, AddEditChapterCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdChapterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditChapterCommand> Handle(GetByIdChapterQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Chapter>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditChapterCommand>(table);

        }
    }
    
}
