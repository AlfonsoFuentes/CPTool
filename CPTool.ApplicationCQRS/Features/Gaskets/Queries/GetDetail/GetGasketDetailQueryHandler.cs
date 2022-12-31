using AutoMapper;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetDetail
{
    public class GetGasketDetailQueryHandler : IRequestHandler<GetGasketDetailQuery, CommandGasket>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetGasketDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandGasket> Handle(GetGasketDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryGasket.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandGasket>(table);
            return dto;
        }
    }
}
