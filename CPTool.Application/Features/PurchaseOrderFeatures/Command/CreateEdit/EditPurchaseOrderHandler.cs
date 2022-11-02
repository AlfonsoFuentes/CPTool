using CPTool.Application.Contracts.Persistence;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    internal class PurchaseOrderHandler : AddEditBaseHandler<AddPurchaseOrder, EditPurchaseOrder, PurchaseOrder>, IRequestHandler<EditPurchaseOrder, Result<int>>
    {

        public PurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPurchaseOrder> logger)
            : base(unitofwork, mapper, logger)
        {

        }
        public override async Task<Result<int>> Handle(EditPurchaseOrder command, CancellationToken cancellationToken)
        {


            try
            {
                if (command.Id == 0)
                {
                    var addcommand = _mapper.Map<AddPurchaseOrder>(command);
                    var table = _mapper.Map<PurchaseOrder>(addcommand);
                    _unitOfWork.Repository<PurchaseOrder>().Add(table);

                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(PurchaseOrder)}");
                }
                else
                {
                    var table = await _unitOfWork.Repository<PurchaseOrder>().GetByIdAsync(command.Id);
                    if (table != null)
                    {
                        var addcommand = _mapper.Map<AddPurchaseOrder>(command);
                        _mapper.Map(addcommand, table, typeof(AddPurchaseOrder), typeof(PurchaseOrder));

                        _unitOfWork.Repository<PurchaseOrder>().Update(table);
                        await _unitOfWork.Complete();
                        await UpdateTask(command);
                        return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Updated in {nameof(PurchaseOrder)}");
                    }
                    return await Result<int>.FailAsync("Not found!!");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
        async Task UpdateTask(EditPurchaseOrder command)
        {
            var table = await _unitOfWork.Repository<Taks>().GetByIdAsync(command.EditTaks!.Id);
            if (table != null)
            {
                var addcommand = _mapper.Map<AddTaks>(command.EditTaks!);

                if (command.PurchaseOrderStatus== PurchaseOrderStatus.Created)
                {
                    addcommand.Name = $"Receive PO {command.PONumber}";
                }
                else if(command.PurchaseOrderStatus == PurchaseOrderStatus.Received)
                {
                    addcommand.Name = $"Install PO {command.PONumber}";
                }
                else if(command.PurchaseOrderStatus == PurchaseOrderStatus.Installed)
                {
                    addcommand.Name = $"Closed Task PO {command.PONumber}";
                    addcommand.TaksStatus = TaksStatus.Completed;
                    addcommand.CompletionDate = DateTime.Now;
                }
               
                _mapper.Map(addcommand, table, typeof(AddTaks), typeof(PurchaseOrder));

                _unitOfWork.Repository<Taks>().Update(table);
                await _unitOfWork.Complete();

            }
        }

    }
}
