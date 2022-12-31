using AutoMapper;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Queries.GetDetail
{
    public class GetContingencyItemDetailQueryHandler : IRequestHandler<GetContingencyItemDetailQuery, CommandContingencyItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetContingencyItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandContingencyItem> Handle(GetContingencyItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryContingencyItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandContingencyItem>(table);
            return dto;
        }
    }
}
