
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Wires.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Wires.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Wires.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Wires.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IWireService
    {
        Task<DeleteWireCommandResponse> Delete(int id);
        Task<WireCommandResponse> AddUpdate(CommandWire command);

        Task<CommandWire> GetById(int id);

        Task<List<CommandWire>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandWire> List);
    }
    public class WireService : IWireService
    {
        protected readonly IMediator mediator;

        public WireService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteWireCommandResponse> Delete(int id)
        {
            DeleteWireCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<WireCommandResponse> AddUpdate(CommandWire command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandWire> GetById(int id)
        {
            GetWireDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandWire>> GetAll()
        {
            GetWiresListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandWire> List)
        {
            ExportWiresQuery export = new();
            export.Type = type; 
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
