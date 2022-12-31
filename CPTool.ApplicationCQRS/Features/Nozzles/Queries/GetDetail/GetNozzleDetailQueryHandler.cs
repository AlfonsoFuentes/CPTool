using AutoMapper;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetDetail
{
    public class GetNozzleDetailQueryHandler : IRequestHandler<GetNozzleDetailQuery, CommandNozzle>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetNozzleDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandNozzle> Handle(GetNozzleDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryNozzle.GetByIdAsync(request.Id);

            if(table!.ConnectedToId!=null)
            {
                table!.ConnectedTo = await _UnitOfWork.RepositoryMWOItem.GetByIdAsync(table!.ConnectedToId.Value);
            }
            var dto = _mapper.Map<CommandNozzle>(table);
            return dto;
        }
    }
}
