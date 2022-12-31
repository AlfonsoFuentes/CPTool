using AutoMapper;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Queries.GetDetail
{
    public class GetFoundationItemDetailQueryHandler : IRequestHandler<GetFoundationItemDetailQuery, CommandFoundationItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetFoundationItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandFoundationItem> Handle(GetFoundationItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryFoundationItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandFoundationItem>(table);
            return dto;
        }
    }
}
