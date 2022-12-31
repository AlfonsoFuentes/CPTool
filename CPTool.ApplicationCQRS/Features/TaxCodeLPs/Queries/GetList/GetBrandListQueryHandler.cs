using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetList;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetList
{
    public class GetTaxCodeLPListQueryHandler : IRequestHandler<GetTaxCodeLPsListQuery, List<CommandTaxCodeLP>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxCodeLPListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandTaxCodeLP>> Handle(GetTaxCodeLPsListQuery request, CancellationToken cancellationToken)
        {
            var allTaxCodeLP = (await _UnitOfWork.RepositoryTaxCodeLP.GetAllAsync());


            foreach(var row in allTaxCodeLP)
            {
                row.Suppliers = (await _UnitOfWork.RepositorySupplier.GetAllAsync(x => x.TaxCodeLPId == row.Id)).ToImmutableList();
            }
            return _mapper.Map<List<CommandTaxCodeLP>>(allTaxCodeLP);
        }
    }
}
