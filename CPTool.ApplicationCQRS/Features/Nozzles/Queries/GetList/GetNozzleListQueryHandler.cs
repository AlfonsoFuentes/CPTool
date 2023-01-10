using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetList
{
    public class GetNozzleListQueryHandler : IRequestHandler<GetNozzlesListQuery, List<CommandNozzle>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetNozzleListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandNozzle>> Handle(GetNozzlesListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Nozzle> allNozzle = null!;

            if (request.MWOItemId != 0)
            {
                allNozzle = await _UnitOfWork.RepositoryNozzle.GetAllAsync(x => x.MWOItemId == request.MWOItemId);
            }
           
            //foreach (var row in allNozzle)
            //{
            //    if (row!.ConnectedToId != null)
            //    {
            //        row!.ConnectedTo = await _UnitOfWork.RepositoryMWOItem.GetByIdAsync(row!.ConnectedToId.Value);
            //    }
            //}
            return _mapper.Map<List<CommandNozzle>>(allNozzle);
        }
    }
}
