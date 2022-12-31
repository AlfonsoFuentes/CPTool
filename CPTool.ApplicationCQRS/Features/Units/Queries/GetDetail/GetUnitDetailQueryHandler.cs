using AutoMapper;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Units.Queries.GetDetail
{
    public class GetUnitDetailQueryHandler : IRequestHandler<GetUnitDetailQuery, CommandUnit>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUnitDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandUnit> Handle(GetUnitDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEntityUnit.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandUnit>(table);
            return dto;
        }
    }
}
