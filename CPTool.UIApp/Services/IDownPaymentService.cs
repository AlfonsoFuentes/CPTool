
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DownPayments.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.DownPayments.Commands.Delete;

using CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.DownPayments.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetList;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.UIApp.Services
{
    public class DownPaymentDialogData
    {
        public string ButtonName { get; set; } = string.Empty;
    }

    public interface IDownPaymentsService
    {
        Task<DeleteDownPaymentCommandResponse> Delete(int id);
        Task<DownPaymentCommandResponse> AddUpdate(CommandDownPayment command);

        Task<CommandDownPayment> GetById(int id);

        Task<List<CommandDownPayment>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandDownPayment> List);
        Task<DownPaymentDialogData> GetDataDialog(CommandDownPayment model);
    }
    public class DownPaymentsService : IDownPaymentsService
    {
        protected readonly IMediator mediator;

        public DownPaymentsService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteDownPaymentCommandResponse> Delete(int id)
        {
            DeleteDownPaymentCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<DownPaymentCommandResponse> AddUpdate(CommandDownPayment command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandDownPayment> GetById(int id)
        {
            GetDownPaymentDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandDownPayment>> GetAll()
        {
            GetDownPaymentsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandDownPayment> List)
        {
            ExportDownPaymentsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public Task<DownPaymentDialogData> GetDataDialog(CommandDownPayment Model)
        {
            DownPaymentDialogData dialogData = new();

            dialogData.ButtonName = Model.DownpaymentStatus == DownpaymentStatus.Draft ? "Create Downpayment" :
           Model.DownpaymentStatus == DownpaymentStatus.Created ? "Approve Downpayment" :
           Model.DownpaymentStatus == DownpaymentStatus.Approved ? "Pay Downpayment" : "Close Downpayment";
            return Task.FromResult(dialogData);
        }

        //public async Task<DownPaymentsDialogData> GetDataDialog()
        //{
        //    DownPaymentsDialogData datadialog = new();
        //    GetPropertyPackagesListQuery querypropertypackage = new();
        //    datadialog.PropertyPackages = await mediator.Send(querypropertypackage);
        //    return datadialog;

        //}
    }
}
