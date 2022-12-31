using AutoMapper;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetDetail
{
    public class GetDownPaymentDetailQueryHandler : IRequestHandler<GetDownPaymentDetailQuery, CommandDownPayment>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDownPaymentDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandDownPayment> Handle(GetDownPaymentDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryDownPayment.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandDownPayment>(table);
            return dto;
        }
    }
}
