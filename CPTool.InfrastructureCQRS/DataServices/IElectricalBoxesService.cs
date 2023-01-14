
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IElectricalBoxService
    {
        Task<DeleteElectricalBoxCommandResponse> Delete(int id);
        Task<ElectricalBoxCommandResponse> AddUpdate(CommandElectricalBox command);

        Task<CommandElectricalBox> GetById(int id);

        Task<List<CommandElectricalBox>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandElectricalBox> List);
    }
    public class ElectricalBoxService : IElectricalBoxService
    {
        protected readonly IMediator mediator;

        public ElectricalBoxService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteElectricalBoxCommandResponse> Delete(int id)
        {
            DeleteElectricalBoxCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<ElectricalBoxCommandResponse> AddUpdate(CommandElectricalBox command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandElectricalBox> GetById(int id)
        {
            GetElectricalBoxDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandElectricalBox>> GetAll()
        {
            GetElectricalBoxsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandElectricalBox> List)
        {
            ExportElectricalBoxsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
