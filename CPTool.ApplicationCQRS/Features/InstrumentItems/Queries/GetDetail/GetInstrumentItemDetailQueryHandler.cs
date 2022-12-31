using AutoMapper;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetDetail
{
    public class GetInstrumentItemDetailQueryHandler : IRequestHandler<GetInstrumentItemDetailQuery, CommandInstrumentItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetInstrumentItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandInstrumentItem> Handle(GetInstrumentItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryInstrumentItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandInstrumentItem>(table);
            return dto;
        }
    }
}
