using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList
{
    public class GetMaterialListQueryHandler : IRequestHandler<GetMaterialsListQuery, List<CommandMaterial>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMaterialListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMaterial>> Handle(GetMaterialsListQuery request, CancellationToken cancellationToken)
        {
            var allMaterial = (await _UnitOfWork.RepositoryMaterial.GetAllAsync());
            return _mapper.Map<List<CommandMaterial>>(allMaterial);
        }
    }
}
