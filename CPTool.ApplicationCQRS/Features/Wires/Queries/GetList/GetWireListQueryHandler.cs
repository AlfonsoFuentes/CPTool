using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Wires.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Wires.Queries.GetList
{
    public class GetWireListQueryHandler : IRequestHandler<GetWiresListQuery, List<CommandWire>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetWireListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandWire>> Handle(GetWiresListQuery request, CancellationToken cancellationToken)
        {
            var allWire = (await _UnitOfWork.RepositoryWire.GetAllAsync());
            return _mapper.Map<List<CommandWire>>(allWire);
        }
    }
}
