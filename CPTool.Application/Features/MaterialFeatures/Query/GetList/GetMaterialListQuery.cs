using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Query.GetList;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;

namespace CPTool.Application.Features.MaterialFeatures.Query.GetList
{

    public class GetMaterialListQuery : GetListQuery, IRequest<List<EditMaterial>>
    {



    }
    public class GetMaterialListQueryHandler : GetListQueryHandler<EditMaterial, Material, GetMaterialListQuery>,
        IRequestHandler<GetMaterialListQuery, List<EditMaterial>>
    {
        public GetMaterialListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
