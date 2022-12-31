using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList
{
    public class GetMWOTypeListQueryHandler : IRequestHandler<GetMWOTypesListQuery, List<CommandMWOType>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOTypeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWOType>> Handle(GetMWOTypesListQuery request, CancellationToken cancellationToken)
        {
            var allMWOType = (await _UnitOfWork.RepositoryMWOType.GetAllAsync());
            return _mapper.Map<List<CommandMWOType>>(allMWOType);
        }
    }
}
