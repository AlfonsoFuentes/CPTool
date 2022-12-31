using AutoMapper;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetDetail
{
    public class GetReadoutDetailQueryHandler : IRequestHandler<GetReadoutDetailQuery, CommandReadout>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetReadoutDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandReadout> Handle(GetReadoutDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryReadout.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandReadout>(table);
            return dto;
        }
    }
}
