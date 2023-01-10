using AutoMapper;
using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Queries.GetDetail
{
    public class GetSpecificationDetailQueryHandler : IRequestHandler<GetSpecificationDetailQuery, CommandSpecification>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSpecificationDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandSpecification> Handle(GetSpecificationDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositorySpecification.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandSpecification>(table);
            return dto;
        }
    }
}
