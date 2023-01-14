
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ControlLoops.Queries.Export;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ControlLoops.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public class ControlLoopDialogData
    {
        public List<CommandSignal> SignalsIn { get; set; } = new();
        public List<CommandSignal> SignalsOut { get; set; } = new();
    }
    public interface IControlLoopService
    {
        Task<DeleteControlLoopCommandResponse> Delete(int id);
        Task<ControlLoopCommandResponse> AddUpdate(CommandControlLoop command);

        Task<CommandControlLoop> GetById(int id);

        Task<List<CommandControlLoop>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandControlLoop> List);
        Task<ControlLoopDialogData> GetDialogData(CommandControlLoop Model);
    }
    public class ControlLoopService : IControlLoopService
    {
        protected readonly IMediator mediator;

        public ControlLoopService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteControlLoopCommandResponse> Delete(int id)
        {
            DeleteControlLoopCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<ControlLoopCommandResponse> AddUpdate(CommandControlLoop command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandControlLoop> GetById(int id)
        {
            GetControlLoopDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandControlLoop>> GetAll(int MWOId)
        {
            GetControlLoopsListQuery command = new()
            {
                MWOId = MWOId
            };
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandControlLoop> List)
        {
            ExportControlLoopsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<ControlLoopDialogData> GetDialogData(CommandControlLoop Model)
        {
            ControlLoopDialogData response = new();
            GetSignalsListQuery signalquery = new()
            {
                MWOId = Model.MWO.Id
            };
            var signals = await mediator.Send(signalquery);
            response.SignalsIn = signals.Where(x =>
                           x.IOType == IOType.In && x.SignalModifier != null && x.SignalModifier?.Name == "Scaled").ToList();

            if (Model.Id == 0 && (Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control))
            {
                response.SignalsIn = response.SignalsIn.Where(x => x.ProcessVariables.Count == 0).ToList();
            }


            response.SignalsOut = signals.Where(x =>
                            x.IOType == IOType.Out
        && x.SignalModifier != null && x.SignalModifier?.Name == "Target").ToList();

            if (Model.Id == 0 && (Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control))
            {
                response.SignalsOut = response.SignalsOut.Where(x => x.ControlledVariables.Count == 0).ToList();
            }

            return response;
        }
    }
}
