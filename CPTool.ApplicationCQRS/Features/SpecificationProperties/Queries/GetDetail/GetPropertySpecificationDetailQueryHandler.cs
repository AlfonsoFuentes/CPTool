using AutoMapper;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetDetail
{
    public class GetPropertySpecificationDetailQueryHandler : IRequestHandler<GetPropertySpecificationDetailQuery, CommandPropertySpecification>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPropertySpecificationDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPropertySpecification> Handle(GetPropertySpecificationDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPropertySpecification.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPropertySpecification>(table);
            return dto;
        }
    }
}
