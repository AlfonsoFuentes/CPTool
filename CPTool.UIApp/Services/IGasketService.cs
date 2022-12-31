using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Gaskets.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
   
    public interface IGasketService
    {
        Task<DeleteGasketCommandResponse> Delete(int id);
        Task<GasketCommandResponse> AddUpdate(CommandGasket command);

        Task<CommandGasket> GetById(int id);

        Task<List<CommandGasket>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type);
    }
    public class GasketService : IGasketService
    {
        protected readonly IMediator mediator;

        public GasketService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteGasketCommandResponse> Delete(int id)
        {
            DeleteGasketCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<GasketCommandResponse> AddUpdate(CommandGasket command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandGasket> GetById(int id)
        {
            GetGasketDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandGasket>> GetAll()
        {
            GetGasketsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportGasketsQuery export = new();
            export.Type = type;
            return await mediator.Send(export);

        }
    }
}
