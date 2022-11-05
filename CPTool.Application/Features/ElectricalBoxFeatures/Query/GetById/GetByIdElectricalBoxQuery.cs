using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetById;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;

namespace CPTool.Application.Features.ElectricalBoxFeatures.Query.GetById
{

    public class GetByIdElectricalBoxQuery : GetByIdQuery, IRequest<EditElectricalBox>
    {
        public GetByIdElectricalBoxQuery() { }
       
    }
    public class GetByIdElectricalBoxQueryHandler :
        GetByIdQueryHandler<EditElectricalBox, ElectricalBox, GetByIdElectricalBoxQuery>, 
        IRequestHandler<GetByIdElectricalBoxQuery, EditElectricalBox>
    {

    
        public GetByIdElectricalBoxQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }    
                                                 
        
    }

}
