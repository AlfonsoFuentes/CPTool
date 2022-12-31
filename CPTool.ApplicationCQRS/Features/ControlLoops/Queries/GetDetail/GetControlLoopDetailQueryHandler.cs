using AutoMapper;
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetDetail
{
    public class GetControlLoopDetailQueryHandler : IRequestHandler<GetControlLoopDetailQuery, CommandControlLoop>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetControlLoopDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandControlLoop> Handle(GetControlLoopDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryControlLoop.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandControlLoop>(table);
            return dto;
        }
    }
}
