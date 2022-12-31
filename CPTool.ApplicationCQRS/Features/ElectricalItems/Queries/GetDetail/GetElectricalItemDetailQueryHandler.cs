using AutoMapper;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetDetail
{
    public class GetElectricalItemDetailQueryHandler : IRequestHandler<GetElectricalItemDetailQuery, CommandElectricalItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetElectricalItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandElectricalItem> Handle(GetElectricalItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryElectricalItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandElectricalItem>(table);
            return dto;
        }
    }
}
