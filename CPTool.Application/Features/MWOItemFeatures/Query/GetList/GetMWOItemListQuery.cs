using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetList;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetList
{

    public class GetMWOItemListQuery : GetListQuery, IRequest<List<EditMWOItem>>
    {
       

       
    }
    public class GetMWOItemListQueryHandler :
        GetListQueryHandler<EditMWOItem, MWOItem, GetMWOItemListQuery>, 
        IRequestHandler<GetMWOItemListQuery, List<EditMWOItem>>
    {
        public GetMWOItemListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditMWOItem>> Handle(GetMWOItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWOItem.GetAllAsync();
            list=list.OrderBy(x=>x.ChapterId).ToList();

            var retorno = _mapper.Map<List<EditMWOItem>>(list);
            return retorno;

        }
    }
}
