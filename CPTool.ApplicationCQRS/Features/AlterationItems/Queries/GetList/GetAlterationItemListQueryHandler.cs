using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.AlterationItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Queries.GetList
{
    public class GetAlterationItemListQueryHandler : IRequestHandler<GetAlterationItemsListQuery, List<CommandAlterationItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetAlterationItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandAlterationItem>> Handle(GetAlterationItemsListQuery request, CancellationToken cancellationToken)
        {
            var allAlterationItem = (await _UnitOfWork.RepositoryAlterationItem.GetAllAsync());
            return _mapper.Map<List<CommandAlterationItem>>(allAlterationItem);
        }
    }
}
