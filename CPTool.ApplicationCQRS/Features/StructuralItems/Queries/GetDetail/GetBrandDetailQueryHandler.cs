using AutoMapper;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.StructuralItems.Queries.GetDetail
{
    public class GetStructuralItemDetailQueryHandler : IRequestHandler<GetStructuralItemDetailQuery, CommandStructuralItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetStructuralItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandStructuralItem> Handle(GetStructuralItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryStructuralItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandStructuralItem>(table);
            return dto;
        }
    }
}
