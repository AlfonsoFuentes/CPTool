using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetList;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetList
{
    public class GetTaxCodeLDListQueryHandler : IRequestHandler<GetTaxCodeLDsListQuery, List<CommandTaxCodeLD>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxCodeLDListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandTaxCodeLD>> Handle(GetTaxCodeLDsListQuery request, CancellationToken cancellationToken)
        {
            var allTaxCodeLD = (await _UnitOfWork.RepositoryTaxCodeLD.GetAllAsync());
            foreach (var row in allTaxCodeLD)
            {
                row.Suppliers = (await _UnitOfWork.RepositorySupplier.GetAllAsync(x => x.TaxCodeLDId == row.Id)).ToImmutableList();
            }
            return _mapper.Map<List<CommandTaxCodeLD>>(allTaxCodeLD);
        }
    }
}
