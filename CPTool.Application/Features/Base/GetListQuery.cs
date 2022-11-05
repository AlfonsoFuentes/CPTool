using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;
using System.Xml.Linq;

namespace CPTool.Application.Features.Base
{
    public class GetListQuery
    {
        public virtual bool FilterFunc(EditCommand element, string searchString)
        {

           
            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;


        }
        
    }
    public class GetListQueryHandler<TEdit, TEntity, TGetList>
        where TEdit : EditCommand, new()
        where TEntity : BaseDomainModel
        where TGetList : GetListQuery
    {

        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitofwork;
        public GetListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<List<TEdit>> Handle(TGetList request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TEntity>().GetAllAsync();

            return _mapper.Map<List<TEdit>>(list);

        }
    }
}
