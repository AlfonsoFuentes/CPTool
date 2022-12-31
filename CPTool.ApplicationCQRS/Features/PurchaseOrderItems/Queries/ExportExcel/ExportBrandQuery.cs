using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.ExportExcel
{
    public class ExportPurchaseOrderItemQuery : IRequest<byte[]>
    {
        public Func<CommandPurchaseOrderItem, bool>? Filter { get; set; }
        public Func<CommandPurchaseOrderItem, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportPurchaseOrderItemQueryHandler :
         IRequestHandler<ExportPurchaseOrderItemQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandPurchaseOrderItem _dto = new();
        public ExportPurchaseOrderItemQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportPurchaseOrderItemQuery request, CancellationToken cancellationToken)
        {


            var allPurchaseOrderItem = (await _UnitOfWork.RepositoryPurchaseOrderItem.GetAllAsync());
            var allPurchaseOrderItemDTO= _mapper.Map<List<CommandPurchaseOrderItem>>(allPurchaseOrderItem);
            if (request.Filter != null)
            {
                allPurchaseOrderItemDTO = allPurchaseOrderItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPurchaseOrderItemDTO = allPurchaseOrderItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allPurchaseOrderItemDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandPurchaseOrderItem, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "PurchaseOrderItem");
            return result;
        }
    }
}
