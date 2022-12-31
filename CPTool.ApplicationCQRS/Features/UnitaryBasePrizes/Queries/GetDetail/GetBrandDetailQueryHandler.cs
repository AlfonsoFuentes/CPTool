using AutoMapper;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetDetail
{
    public class GetUnitaryBasePrizeDetailQueryHandler : IRequestHandler<GetUnitaryBasePrizeDetailQuery, CommandUnitaryBasePrize>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUnitaryBasePrizeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandUnitaryBasePrize> Handle(GetUnitaryBasePrizeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryUnitaryBasePrize.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandUnitaryBasePrize>(table);
            return dto;
        }
    }
}
