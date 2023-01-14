
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.SignalTypes.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.SignalTypes.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface ISignalTypeService
    {
        Task<DeleteSignalTypeCommandResponse> Delete(int id);
        Task<SignalTypeCommandResponse> AddUpdate(CommandSignalType command);

        Task<CommandSignalType> GetById(int id);

        Task<List<CommandSignalType>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandSignalType> List);
    }
    public class SignalTypeService : ISignalTypeService
    {
        protected readonly IMediator mediator;

        public SignalTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteSignalTypeCommandResponse> Delete(int id)
        {
            DeleteSignalTypeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<SignalTypeCommandResponse> AddUpdate(CommandSignalType command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandSignalType> GetById(int id)
        {
            GetSignalTypeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandSignalType>> GetAll()
        {
            GetSignalTypesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandSignalType> List)
        {
            ExportSignalTypesQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
