using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetDetail
{
    public class GetTaxCodeLDDetailQueryHandler : IRequestHandler<GetTaxCodeLDDetailQuery, CommandTaxCodeLD>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxCodeLDDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandTaxCodeLD> Handle(GetTaxCodeLDDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryTaxCodeLD.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandTaxCodeLD>(table);
            return dto;
        }
    }
}
