
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Queries.Export;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Takss.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Takss.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Takss.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface ITaksService
    {
        Task<DeleteTaksCommandResponse> Delete(int id);
        Task<TaksCommandResponse> AddUpdate(CommandTaks command);

        Task<CommandTaks> GetById(int id);

        Task<List<CommandTaks>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandTaks> List);
    }
    public class TaksService : ITaksService
    {
        protected readonly IMediator mediator;

        public TaksService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteTaksCommandResponse> Delete(int id)
        {
            DeleteTaksCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<TaksCommandResponse> AddUpdate(CommandTaks command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandTaks> GetById(int id)
        {
            GetTaksDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandTaks>> GetAll()
        {
            GetTakssListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandTaks> List)
        {
            ExportTakssQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
