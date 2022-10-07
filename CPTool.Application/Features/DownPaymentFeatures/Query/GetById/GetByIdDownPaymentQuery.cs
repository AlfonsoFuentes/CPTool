using CPTool.Application.Features.DownPaymentFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Query.GetById
{
    
    public class GetByIdDownPaymentQuery : GetByIdQuery, IRequest<AddEditDownPaymentCommand>
    {
    }
    public class GetByIdDownPaymentQueryHandler : IRequestHandler<GetByIdDownPaymentQuery, AddEditDownPaymentCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDownPaymentQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditDownPaymentCommand> Handle(GetByIdDownPaymentQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DownPayment>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditDownPaymentCommand>(table);

        }
    }
    
}
