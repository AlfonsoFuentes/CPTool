
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetList;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;

namespace CPTool.Application.Features.ElectricalBoxFeatures.Query.GetList
{

    public class GetElectricalBoxListQuery : GetListQuery, IRequest<List<EditElectricalBox>>
    {



    }
    public class GetElectricalBoxListQueryHandler :
         GetListQueryHandler<EditElectricalBox, ElectricalBox, GetElectricalBoxListQuery>, 
        IRequestHandler<GetElectricalBoxListQuery, List<EditElectricalBox>>
    {


        public GetElectricalBoxListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
    }
}
