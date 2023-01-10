using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetList
{
    public class GetPropertySpecificationListQueryHandler : IRequestHandler<GetPropertySpecificationsListQuery, List<CommandPropertySpecification>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPropertySpecificationListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPropertySpecification>> Handle(GetPropertySpecificationsListQuery request, CancellationToken cancellationToken)
        {
            var allPropertySpecification = (await _UnitOfWork.RepositoryPropertySpecification.GetAllAsync());
           
            return _mapper.Map<List<CommandPropertySpecification>>(allPropertySpecification);
        }
    }
}
