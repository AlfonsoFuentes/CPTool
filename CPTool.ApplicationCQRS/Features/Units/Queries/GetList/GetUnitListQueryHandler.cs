using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Units.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Units.Queries.GetList
{
    public class GetUnitListQueryHandler : IRequestHandler<GetUnitsListQuery, List<CommandUnit>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUnitListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandUnit>> Handle(GetUnitsListQuery request, CancellationToken cancellationToken)
        {
            var allUnit = (await _UnitOfWork.RepositoryEntityUnit.GetAllAsync());
            return _mapper.Map<List<CommandUnit>>(allUnit);
        }
    }
}
