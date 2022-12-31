using AutoMapper;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.ExportCSV
{
    public class GetPurchaseOrderItemsExportQueryHandler : IRequestHandler<GetPurchaseOrderItemsExportQuery, PurchaseOrderItemExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetPurchaseOrderItemsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<PurchaseOrderItemExportFileVm> Handle(GetPurchaseOrderItemsExportQuery request, CancellationToken cancellationToken)
        {
            var allPurchaseOrderItems = _mapper.Map<List<CommandPurchaseOrderItem>>((await _UnitOfWork.RepositoryPurchaseOrderItem.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allPurchaseOrderItems);

            var eventExportFileDto = new PurchaseOrderItemExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
