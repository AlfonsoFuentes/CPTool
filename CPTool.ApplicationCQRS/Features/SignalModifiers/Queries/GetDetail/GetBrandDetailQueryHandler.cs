using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetDetail
{
    public class GetSignalModifierDetailQueryHandler : IRequestHandler<GetSignalModifierDetailQuery, CommandSignalModifier>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalModifierDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandSignalModifier> Handle(GetSignalModifierDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositorySignalModifier.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandSignalModifier>(table);
            return dto;
        }
    }
}
