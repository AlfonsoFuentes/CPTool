using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using System.Collections.Generic;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetList
{
    public class GetMWOListQueryHandler : IRequestHandler<GetMWOsListQuery, List<CommandMWO>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWO>> Handle(GetMWOsListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<MWO> allMWO = null!;
            allMWO = (await _UnitOfWork.RepositoryMWO.GetAllAsync());

            return _mapper.Map<List<CommandMWO>>(allMWO);
        }
    }
}
