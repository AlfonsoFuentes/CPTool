using AutoMapper;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Queries.GetDetail
{
    public class GetTestingItemDetailQueryHandler : IRequestHandler<GetTestingItemDetailQuery, CommandTestingItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTestingItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandTestingItem> Handle(GetTestingItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryTestingItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandTestingItem>(table);
            return dto;
        }
    }
}
