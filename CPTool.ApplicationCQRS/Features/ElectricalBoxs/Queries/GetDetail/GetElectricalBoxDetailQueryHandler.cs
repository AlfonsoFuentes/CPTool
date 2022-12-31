using AutoMapper;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetDetail
{
    public class GetElectricalBoxDetailQueryHandler : IRequestHandler<GetElectricalBoxDetailQuery, CommandElectricalBox>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetElectricalBoxDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandElectricalBox> Handle(GetElectricalBoxDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryElectricalBox.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandElectricalBox>(table);
            return dto;
        }
    }
}
