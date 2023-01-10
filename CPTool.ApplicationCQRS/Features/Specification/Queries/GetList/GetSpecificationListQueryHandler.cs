using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Specifications.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Queries.GetList
{
    public class GetSpecificationListQueryHandler : IRequestHandler<GetSpecificationsListQuery, List<CommandSpecification>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSpecificationListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSpecification>> Handle(GetSpecificationsListQuery request, CancellationToken cancellationToken)
        {
            var allSpecification = (await _UnitOfWork.RepositorySpecification.GetAllAsync());
           
            return _mapper.Map<List<CommandSpecification>>(allSpecification);
        }
    }
}
