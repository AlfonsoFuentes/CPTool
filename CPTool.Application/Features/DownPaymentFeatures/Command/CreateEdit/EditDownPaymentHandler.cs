using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    internal class DownPaymentHandler : AddEditBaseHandler<AddDownPayment, EditDownPayment, DownPayment>, IRequestHandler<EditDownPayment, Result<int>>
    {


        public DownPaymentHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditDownPayment> logger)
            : base(unitofwork, mapper, logger)
        {

        }
        public override async Task<Result<int>> Handle(EditDownPayment command, CancellationToken cancellationToken)
        {


            try
            {
                if (command.Id == 0)
                {
                    var addcommand = _mapper.Map<AddDownPayment>(command);
                    var table = _mapper.Map<DownPayment>(addcommand);
                    _unitOfWork.Repository<DownPayment>().Add(table);

                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                   await CreateTask(command);
                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(DownPayment)}");
                }
                else
                {
                    var table = await _unitOfWork.Repository<DownPayment>().GetByIdAsync(command.Id);
                    if (table != null)
                    {
                        var addcommand = _mapper.Map<AddDownPayment>(command);
                        _mapper.Map(addcommand, table, typeof(AddDownPayment), typeof(DownPayment));

                        _unitOfWork.Repository<DownPayment>().Update(table);
                        await _unitOfWork.Complete();
                        await UpdateTask(command);
                        return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Updated in {nameof(DownPayment)}");
                    }
                    return await Result<int>.FailAsync("Not found!!");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
        async Task CreateTask(EditDownPayment downPayment)
        {
            EditTaks editTaks = new();
            editTaks.MWO = downPayment.PurchaseOrder!.MWO;
            editTaks.Name = $"Approve Dowpayment {downPayment.Name}";
            editTaks.PurchaseOrder = downPayment.PurchaseOrder;
            editTaks.DownPayment = downPayment;
            editTaks.TaksType = TaksType.Automatic;
            editTaks.CreatedDate = DateTime.Now;
            editTaks.TaksStatus = TaksStatus.Pending;
            var addcommandTaks = _mapper.Map<AddTaks>(editTaks);
            var table = _mapper.Map<Taks>(addcommandTaks);

            _unitOfWork.Repository<Taks>().Add(table);

            await _unitOfWork.Complete();
        }
        async Task UpdateTask(EditDownPayment command)
        {
            var table = await _unitOfWork.Repository<Taks>().GetByIdAsync(command.EditTaks!.Id);
            if (table != null)
            {
                var addcommand = _mapper.Map<AddTaks>(command.EditTaks!);

                if (command.DownpaymentStatus ==  DownpaymentStatus.Created)
                {
                    addcommand.Name = $"Approve Downpayment {command.Name}";
                }
                else if (command.DownpaymentStatus ==  DownpaymentStatus.Approved)
                {
                    addcommand.Name = $"Pay Downpayment {command.Name}";
                }
                else if (command.DownpaymentStatus ==  DownpaymentStatus.Paid)
                {
                    addcommand.Name = $"Closed Task Downpayment {command.Name}";
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