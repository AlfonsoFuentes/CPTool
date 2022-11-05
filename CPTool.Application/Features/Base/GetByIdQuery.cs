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
      

        public int Id { get; set; }
    }
    public class GetByIdQueryHandler<TEdit, TEntity,TGetById> 
        where TEdit : EditCommand ,new()
        where TEntity : BaseDomainModel
        where TGetById : GetByIdQuery
    {

        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitofwork;
        public GetByIdQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<TEdit> Handle(TGetById request, CancellationToken cancellationToken)
        {
            TEdit result = new TEdit();

            if (request.Id!=0)
            {
                var table = await _unitofwork.Repository<TEntity>().GetByIdAsync(request.Id);
                result = _mapper.Map<TEdit>(table);
            }
            

            return result;

        }
    }
}
