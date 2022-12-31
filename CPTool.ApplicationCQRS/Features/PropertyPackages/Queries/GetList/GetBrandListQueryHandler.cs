using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetList
{
    public class GetPropertyPackageListQueryHandler : IRequestHandler<GetPropertyPackagesListQuery, List<CommandPropertyPackage>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPropertyPackageListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPropertyPackage>> Handle(GetPropertyPackagesListQuery request, CancellationToken cancellationToken)
        {
            var allPropertyPackage = (await _UnitOfWork.RepositoryPropertyPackage.GetAllAsync());
            return _mapper.Map<List<CommandPropertyPackage>>(allPropertyPackage);
        }
    }
}
