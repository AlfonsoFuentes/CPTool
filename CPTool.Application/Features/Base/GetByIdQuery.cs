using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetById;

namespace CPTool.Application.Features.Base
{
    public class GetByIdQuery
    {
        public GetByIdQuery()
        {

        }
      

        public int Id { get; init; }
    }
    public class GetByIdQueryHandler<TEdit, TEntity,TGetById> 
        where TEdit : EditCommand 
        where TEntity : BaseDomainModel
        where TGetById : GetByIdQuery
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<TEdit> Handle(TGetById request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TEntity>().GetByIdAsync(request.Id);

            return _mapper.Map<TEdit>(table);

        }
    }
}
