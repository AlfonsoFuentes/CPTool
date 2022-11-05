using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionFeatures.Query.GetById;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Query.GetById
{

    public class GetByIdDownPaymentQuery : GetByIdQuery, IRequest<EditDownPayment>
    {
        public GetByIdDownPaymentQuery() { }
       
    }
    public class GetByIdDownPaymentQueryHandler : GetByIdQueryHandler<EditDownPayment, DownPayment, GetByIdDownPaymentQuery>, 
        IRequestHandler<GetByIdDownPaymentQuery, EditDownPayment>
    {

      
        public GetByIdDownPaymentQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork,mapper)
        {
            
        }
       
    }
    
}
