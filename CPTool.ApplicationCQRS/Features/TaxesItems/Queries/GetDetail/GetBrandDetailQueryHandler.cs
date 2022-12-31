using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Queries.GetDetail
{
    public class GetTaxesItemDetailQueryHandler : IRequestHandler<GetTaxesItemDetailQuery, CommandTaxesItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaxesItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandTaxesItem> Handle(GetTaxesItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryTaxesItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandTaxesItem>(table);
            return dto;
        }
    }
}
