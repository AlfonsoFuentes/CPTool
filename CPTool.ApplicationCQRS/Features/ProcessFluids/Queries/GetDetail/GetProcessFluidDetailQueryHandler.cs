using AutoMapper;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetDetail
{
    public class GetProcessFluidDetailQueryHandler : IRequestHandler<GetProcessFluidDetailQuery, CommandProcessFluid>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetProcessFluidDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandProcessFluid> Handle(GetProcessFluidDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryProcessFluid.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandProcessFluid>(table);
            return dto;
        }
    }
}
