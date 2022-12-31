using AutoMapper;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Materials.Queries.GetDetail
{
    public class GetMaterialDetailQueryHandler : IRequestHandler<GetMaterialDetailQuery, CommandMaterial>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMaterialDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMaterial> Handle(GetMaterialDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryMaterial.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandMaterial>(table);
            return dto;
        }
    }
}
