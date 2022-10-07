
using CPTool.Application.Features.DownPaymentFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.DownPaymentFeatures.Query.GetList
{

    public class GetDownPaymentListQuery : GetListQuery, IRequest<List<AddEditDownPaymentCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetDownPaymentListQuery, List<AddEditDownPaymentCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditDownPaymentCommand>> Handle(GetDownPaymentListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<DownPayment>().GetAllAsync();

            return _mapper.Map<List<AddEditDownPaymentCommand>>(list);

        }
    }
}
