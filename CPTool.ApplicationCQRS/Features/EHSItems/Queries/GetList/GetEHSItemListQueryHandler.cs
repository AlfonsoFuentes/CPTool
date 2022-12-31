using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.EHSItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Queries.GetList
{
    public class GetEHSItemListQueryHandler : IRequestHandler<GetEHSItemsListQuery, List<CommandEHSItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEHSItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandEHSItem>> Handle(GetEHSItemsListQuery request, CancellationToken cancellationToken)
        {
            var allEHSItem = (await _UnitOfWork.RepositoryEHSItem.GetAllAsync());
            return _mapper.Map<List<CommandEHSItem>>(allEHSItem);
        }
    }
}
