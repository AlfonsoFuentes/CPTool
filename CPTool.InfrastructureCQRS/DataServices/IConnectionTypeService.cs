
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IConnectionTypeService
    {
        Task<DeleteConnectionTypeCommandResponse> Delete(int id);
        Task<ConnectionTypeCommandResponse> AddUpdate(CommandConnectionType command);

        Task<CommandConnectionType> GetById(int id);

        Task<List<CommandConnectionType>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandConnectionType> List);
    }
    public class ConnectionTypeService : IConnectionTypeService
    {
        protected readonly IMediator mediator;

        public ConnectionTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteConnectionTypeCommandResponse> Delete(int id)
        {
            DeleteConnectionTypeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<ConnectionTypeCommandResponse> AddUpdate(CommandConnectionType command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandConnectionType> GetById(int id)
        {
            GetConnectionTypeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandConnectionType>> GetAll()
        {
            GetConnectionTypesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandConnectionType> List)
        {
            ExportConnectionTypesQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
