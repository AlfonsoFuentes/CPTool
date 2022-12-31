using AutoMapper;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetDetail
{
    public class GetConnectionTypeDetailQueryHandler : IRequestHandler<GetConnectionTypeDetailQuery, CommandConnectionType>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetConnectionTypeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandConnectionType> Handle(GetConnectionTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryConnectionType.FindAsync(request.Id);
            var dto = _mapper.Map<CommandConnectionType>(table);
            return dto;
        }
    }
}
