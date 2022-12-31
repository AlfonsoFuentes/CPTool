using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetDetail
{
    public class GetTaxCodeLPDetailQueryHandler : IRequestHandler<GetTaxCodeLPDetailQuery, CommandTaxCodeLP>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxCodeLPDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandTaxCodeLP> Handle(GetTaxCodeLPDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryTaxCodeLP.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandTaxCodeLP>(table);
            return dto;
        }
    }
}
