using AutoMapper;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetDetail
{
    public class GetPaintingItemDetailQueryHandler : IRequestHandler<GetPaintingItemDetailQuery, CommandPaintingItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPaintingItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPaintingItem> Handle(GetPaintingItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPaintingItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPaintingItem>(table);
            return dto;
        }
    }
}
