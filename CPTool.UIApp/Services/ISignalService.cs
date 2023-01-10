
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Queries.Export;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList;

using CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Signals.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Wires.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public class SignalDialogData
    {
        public List<CommandSignalModifier> SignalModifiers { get; set; } = new();
        public List<CommandSignalType> SignalTypes { get; set; } = new();
        public List<CommandWire> Wires { get; set; } = new();
        public List<CommandFieldLocation> FieldLocations { get; set; } = new();

        public List<CommandElectricalBox> ElectricalBoxs { get; set; } = new();

      
    }
    public interface ISignalService
    {
        Task<DeleteSignalCommandResponse> Delete(int id);
        Task<SignalCommandResponse> AddUpdate(CommandSignal command);

        Task<CommandSignal> GetById(int id);

        Task<List<CommandSignal>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandSignal> List);
        Task<SignalDialogData> GetDialogData();
    }
    public class SignalService : ISignalService
    {
        protected readonly IMediator mediator;

        public SignalService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteSignalCommandResponse> Delete(int id)
        {
            DeleteSignalCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<SignalCommandResponse> AddUpdate(CommandSignal command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandSignal> GetById(int id)
        {
            GetSignalDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandSignal>> GetAll(int MWOId)
        {
            GetSignalsListQuery command = new()
            {
                MWOId = MWOId,
            };
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandSignal> List)
        {
            ExportSignalsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<SignalDialogData> GetDialogData()
        {
            SignalDialogData response = new();

            GetSignalModifiersListQuery getmodifiers = new();
            response.SignalModifiers = await mediator.Send(getmodifiers);

            GetSignalTypesListQuery gettypes = new();
            response.SignalTypes = await mediator.Send(gettypes);

            GetWiresListQuery getWires = new();
            response.Wires = await mediator.Send(getWires);

            GetFieldLocationsListQuery getfields = new();
            response.FieldLocations = await mediator.Send(getfields);

            GetElectricalBoxsListQuery getboxes = new();
            response.ElectricalBoxs = await mediator.Send(getboxes);

           

            return response;
        }
    }
}
