using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ContingencyItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Queries.GetList
{
    public class GetContingencyItemListQueryHandler : IRequestHandler<GetContingencyItemsListQuery, List<CommandContingencyItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetContingencyItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandContingencyItem>> Handle(GetContingencyItemsListQuery request, CancellationToken cancellationToken)
        {
            var allContingencyItem = (await _UnitOfWork.RepositoryContingencyItem.GetAllAsync());
            return _mapper.Map<List<CommandContingencyItem>>(allContingencyItem);
        }
    }
}
