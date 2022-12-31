using AutoMapper;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Wires.Queries.GetDetail
{
    public class GetWireDetailQueryHandler : IRequestHandler<GetWireDetailQuery, CommandWire>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetWireDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandWire> Handle(GetWireDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryWire.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandWire>(table);
            return dto;
        }
    }
}
