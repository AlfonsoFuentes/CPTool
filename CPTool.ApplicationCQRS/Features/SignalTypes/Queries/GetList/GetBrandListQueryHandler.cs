using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetList
{
    public class GetSignalTypeListQueryHandler : IRequestHandler<GetSignalTypesListQuery, List<CommandSignalType>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalTypeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSignalType>> Handle(GetSignalTypesListQuery request, CancellationToken cancellationToken)
        {
            var allSignalType = (await _UnitOfWork.RepositorySignalType.GetAllAsync());
            return _mapper.Map<List<CommandSignalType>>(allSignalType);
        }
    }
}
