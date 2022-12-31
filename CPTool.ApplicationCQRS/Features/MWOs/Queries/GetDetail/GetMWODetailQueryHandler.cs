using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetDetail
{
    public class GetMWODetailQueryHandler : IRequestHandler<GetMWODetailQuery, CommandMWO>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWODetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMWO> Handle(GetMWODetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryMWO.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandMWO>(table);
            return dto;
        }
    }
}
