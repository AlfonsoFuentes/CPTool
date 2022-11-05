
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Query.GetList;
using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Query.GetList
{

    public class GetMeasuredVariableListQuery : GetListQuery, IRequest<List<EditMeasuredVariable>>
    {



    }
    public class GetMeasuredVariableListQueryHandler :
         GetListQueryHandler<EditMeasuredVariable, MeasuredVariable, GetMeasuredVariableListQuery>,
        IRequestHandler<GetMeasuredVariableListQuery, List<EditMeasuredVariable>>
    {
        public GetMeasuredVariableListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
