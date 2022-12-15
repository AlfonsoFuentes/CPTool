using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;


namespace CPTool.Application.Features.PurchaseOrderFeatures
{
    internal class AddEditPurchaseOrderHandler : CommandHandler<EditPurchaseOrder, AddPurchaseOrder, PurchaseOrder>, IRequestHandler<EditPurchaseOrder, Result<int>>
    {

        public AddEditPurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }
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
                    await SavePurchaseOrderItem(command.PurchaseOrderItems);
                    return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(PurchaseOrder)}");
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
                        await SavePurchaseOrderItem(command.PurchaseOrderItems);
                        return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(PurchaseOrder)}");
                    }
                    return await Result<int>.FailAsync("Not found!!");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
        async Task<Result<int>> SavePurchaseOrderItem(List<EditPurchaseOrderItem> list)
        {
            foreach(var command in list)
            {
                if (command.Id == 0)
                {
                    var addcommand = _mapper.Map<AddPurchaseOrderItem>(command);
                    var table = _mapper.Map<PurchaseOrderItem>(addcommand);
                    _unitOfWork.Repository<PurchaseOrderItem>().Add(table);

                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                   
                }
                else
                {
                    var table = await _unitOfWork.Repository<PurchaseOrderItem>().GetByIdAsync(command.Id);
                    if (table != null)
                    {
                        var addcommand = _mapper.Map<AddPurchaseOrderItem>(command);
                        _mapper.Map(addcommand, table, typeof(AddPurchaseOrderItem), typeof(PurchaseOrderItem));

                        _unitOfWork.Repository<PurchaseOrderItem>().Update(table);
                        await _unitOfWork.Complete();
                      
                    }
                    
                }
            }
            return await Result<int>.SuccessAsync($"Added to {nameof(PurchaseOrderItem)}");
        }
        async Task<Result<int>> SavePurchaseTask(List<EditTaks> list)
        {
            foreach (var command in list)
            {
                if (command.Id == 0)
                {
                    var addcommand = _mapper.Map<AddTaks>(command);
                    var table = _mapper.Map<Taks>(addcommand);
                    _unitOfWork.Repository<Taks>().Add(table);

                    await _unitOfWork.Complete();
                    command.Id = table.Id;

                }
                else
                {
                    var table = await _unitOfWork.Repository<Taks>().GetByIdAsync(command.Id);
                    if (table != null)
                    {
                        var addcommand = _mapper.Map<AddTaks>(command);
                        _mapper.Map(addcommand, table, typeof(AddTaks), typeof(Taks));

                        _unitOfWork.Repository<Taks>().Update(table);
                        await _unitOfWork.Complete();

                    }

                }
            }
            return await Result<int>.SuccessAsync($"Added to {nameof(Taks)}");
        }

    }
    internal class DeletePurchaseOrderHandler : DeleteCommandHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<DeleteCommand<EditPurchaseOrder>, IResult>
    {

        public DeletePurchaseOrderHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPurchaseOrderHandler : QueryListHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<QueryList<EditPurchaseOrder>, List<EditPurchaseOrder>>
    {

        public GetListPurchaseOrderHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditPurchaseOrder>> Handle(QueryList<EditPurchaseOrder> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPurchaseOrder.GetAllAsync();
            list = list.OrderBy(x => x.PurchaseOrderStatus).ToList();
            return _mapper.Map<List<EditPurchaseOrder>>(list);


        }
       
    }
    internal class QueryIdPurchaseOrderHandler : QueryIdHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<QueryId<EditPurchaseOrder>, EditPurchaseOrder>

    {


        public QueryIdPurchaseOrderHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPurchaseOrder> Handle(QueryId<EditPurchaseOrder> request, CancellationToken cancellationToken)
        {
            EditPurchaseOrder result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPurchaseOrder.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPurchaseOrder>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPurchaseOrderHandler : QueryExcelHandler<EditPurchaseOrder>, IRequestHandler<QueryExcel<EditPurchaseOrder>, QueryExcel<EditPurchaseOrder>>

    {


        public QueryExcelPurchaseOrderHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
