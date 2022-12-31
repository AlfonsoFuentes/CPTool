using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetList;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetList
{
    public class GetSignalModifierListQueryHandler : IRequestHandler<GetSignalModifiersListQuery, List<CommandSignalModifier>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalModifierListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSignalModifier>> Handle(GetSignalModifiersListQuery request, CancellationToken cancellationToken)
        {
            var allSignalModifier = (await _UnitOfWork.RepositorySignalModifier.GetAllAsync());
            return _mapper.Map<List<CommandSignalModifier>>(allSignalModifier);
        }
    }
}
