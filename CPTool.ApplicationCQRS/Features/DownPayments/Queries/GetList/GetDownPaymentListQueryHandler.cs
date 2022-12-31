using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetList;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetList
{
    public class GetDownPaymentListQueryHandler : IRequestHandler<GetDownPaymentsListQuery, List<CommandDownPayment>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDownPaymentListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandDownPayment>> Handle(GetDownPaymentsListQuery request, CancellationToken cancellationToken)
        {
            var allDownPayment = (await _UnitOfWork.RepositoryDownPayment.GetAllAsync());
            return _mapper.Map<List<CommandDownPayment>>(allDownPayment);
        }
    }
}
