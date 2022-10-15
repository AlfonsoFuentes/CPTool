using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Query.GetById
{

    public class GetByIdDownPaymentQuery : GetByIdQuery, IRequest<EditDownPayment>
    {
        public GetByIdDownPaymentQuery() { }
       
    }
    public class GetByIdDownPaymentQueryHandler : IRequestHandler<GetByIdDownPaymentQuery, EditDownPayment>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDownPaymentQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditDownPayment> Handle(GetByIdDownPaymentQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DownPayment>().GetByIdAsync(request.Id);

            return _mapper.Map<EditDownPayment>(table);

        }
    }
    
}
