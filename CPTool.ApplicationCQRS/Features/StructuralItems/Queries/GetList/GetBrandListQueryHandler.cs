using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.StructuralItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.StructuralItems.Queries.GetList
{
    public class GetStructuralItemListQueryHandler : IRequestHandler<GetStructuralItemsListQuery, List<CommandStructuralItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetStructuralItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandStructuralItem>> Handle(GetStructuralItemsListQuery request, CancellationToken cancellationToken)
        {
            var allStructuralItem = (await _UnitOfWork.RepositoryStructuralItem.GetAllAsync());
            return _mapper.Map<List<CommandStructuralItem>>(allStructuralItem);
        }
    }
}
