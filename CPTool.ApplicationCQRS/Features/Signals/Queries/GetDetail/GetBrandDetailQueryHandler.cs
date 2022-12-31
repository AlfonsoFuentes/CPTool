using AutoMapper;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Signals.Queries.GetDetail
{
    public class GetSignalDetailQueryHandler : IRequestHandler<GetSignalDetailQuery, CommandSignal>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandSignal> Handle(GetSignalDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositorySignal.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandSignal>(table);
            return dto;
        }
    }
}
