using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetDetail
{
    public class GetSignalTypeDetailQueryHandler : IRequestHandler<GetSignalTypeDetailQuery, CommandSignalType>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalTypeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandSignalType> Handle(GetSignalTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositorySignalType.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandSignalType>(table);
            return dto;
        }
    }
}
