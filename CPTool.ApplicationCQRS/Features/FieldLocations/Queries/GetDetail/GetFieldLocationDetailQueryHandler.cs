using AutoMapper;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetDetail
{
    public class GetFieldLocationDetailQueryHandler : IRequestHandler<GetFieldLocationDetailQuery, CommandFieldLocation>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetFieldLocationDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandFieldLocation> Handle(GetFieldLocationDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryFieldLocation.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandFieldLocation>(table);
            return dto;
        }
    }
}
