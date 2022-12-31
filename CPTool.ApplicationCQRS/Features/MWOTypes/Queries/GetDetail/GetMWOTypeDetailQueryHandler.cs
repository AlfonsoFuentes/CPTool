using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetDetail
{
    public class GetMWOTypeDetailQueryHandler : IRequestHandler<GetMWOTypeDetailQuery, CommandMWOType>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOTypeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMWOType> Handle(GetMWOTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryMWOType.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandMWOType>(table);
            return dto;
        }
    }
}
