using AutoMapper;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetDetail
{
    public class GetEngineeringCostItemDetailQueryHandler : IRequestHandler<GetEngineeringCostItemDetailQuery, CommandEngineeringCostItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEngineeringCostItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandEngineeringCostItem> Handle(GetEngineeringCostItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEngineeringCostItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandEngineeringCostItem>(table);
            return dto;
        }
    }
}
