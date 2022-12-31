using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetList
{
    public class GetInstrumentItemListQueryHandler : IRequestHandler<GetInstrumentItemsListQuery, List<CommandInstrumentItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetInstrumentItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandInstrumentItem>> Handle(GetInstrumentItemsListQuery request, CancellationToken cancellationToken)
        {
            var allInstrumentItem = (await _UnitOfWork.RepositoryInstrumentItem.GetAllAsync());
            return _mapper.Map<List<CommandInstrumentItem>>(allInstrumentItem);
        }
    }
}
