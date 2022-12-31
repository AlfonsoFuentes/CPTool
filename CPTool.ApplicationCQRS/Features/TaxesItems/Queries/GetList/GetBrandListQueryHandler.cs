using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.TaxesItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Queries.GetList
{
    public class GetTaxesItemListQueryHandler : IRequestHandler<GetTaxesItemsListQuery, List<CommandTaxesItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxesItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandTaxesItem>> Handle(GetTaxesItemsListQuery request, CancellationToken cancellationToken)
        {
            var allTaxesItem = (await _UnitOfWork.RepositoryTaxesItem.GetAllAsync());
            return _mapper.Map<List<CommandTaxesItem>>(allTaxesItem);
        }
    }
}
