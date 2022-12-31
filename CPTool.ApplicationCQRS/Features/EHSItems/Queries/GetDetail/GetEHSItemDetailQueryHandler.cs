using AutoMapper;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Queries.GetDetail
{
    public class GetEHSItemDetailQueryHandler : IRequestHandler<GetEHSItemDetailQuery, CommandEHSItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEHSItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandEHSItem> Handle(GetEHSItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEHSItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandEHSItem>(table);
            return dto;
        }
    }
}
