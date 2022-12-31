using AutoMapper;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetDetail
{
    public class GetPropertyPackageDetailQueryHandler : IRequestHandler<GetPropertyPackageDetailQuery, CommandPropertyPackage>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPropertyPackageDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPropertyPackage> Handle(GetPropertyPackageDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPropertyPackage.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPropertyPackage>(table);
            return dto;
        }
    }
}
