using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList
{
    public class GetElectricalBoxListQueryHandler : IRequestHandler<GetElectricalBoxsListQuery, List<CommandElectricalBox>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetElectricalBoxListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandElectricalBox>> Handle(GetElectricalBoxsListQuery request, CancellationToken cancellationToken)
        {
            var allElectricalBox = (await _UnitOfWork.RepositoryElectricalBox.GetAllAsync());
            return _mapper.Map<List<CommandElectricalBox>>(allElectricalBox);
        }
    }
}
