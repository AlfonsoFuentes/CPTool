using AutoMapper;
using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Queries.GetDetail
{
    public class GetAlterationItemDetailQueryHandler : IRequestHandler<GetAlterationItemDetailQuery, CommandAlterationItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetAlterationItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandAlterationItem> Handle(GetAlterationItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryAlterationItem.FindAsync(request.Id);
            var dto = _mapper.Map<CommandAlterationItem>(table);
            return dto;
        }
    }
}
