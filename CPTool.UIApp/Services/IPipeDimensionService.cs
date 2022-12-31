
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Queries.Export;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetDetail;

using MediatR;

namespace CPTool.UIApp.Services
{
    public interface IPipeDimensionService
    {
        Task<DeletePipeClassCommandResponse> DeletePipeClass(int id);
        Task<DeletePipeDiameterCommandResponse> DeletePipeDiameter(int id);
        Task<PipeClassCommandResponse> AddUpdatePipeClass(CommandPipeClass command);
        Task<PipeDiameterCommandResponse> AddUpdatePipeDiameter(CommandPipeDiameter command);
        Task<CommandPipeClass> GetByIdPipeClass(int id);
        Task<CommandPipeDiameter> GetByIdPipeDiameter(int id);
        Task<List<CommandPipeClass>> GetAll();

        Task<ExportBaseResponse> GetFiletoExportPipeClass(string type);
        Task<ExportBaseResponse> GetFiletoExportPipeDiameter(string type);
    }
    public class PipeDimensionService : IPipeDimensionService
    {
        protected readonly IMediator mediator;



        public PipeDimensionService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeletePipeClassCommandResponse> DeletePipeClass(int id)
        {
            DeletePipeClassCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;
        }

        public async Task<DeletePipeDiameterCommandResponse> DeletePipeDiameter(int id)
        {
            DeletePipeDiameterCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;
        }

        public async Task<PipeClassCommandResponse> AddUpdatePipeClass(CommandPipeClass command)
        {
            return await mediator.Send(command);
        }

        public async Task<PipeDiameterCommandResponse> AddUpdatePipeDiameter(CommandPipeDiameter command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandPipeClass> GetByIdPipeClass(int id)
        {
            GetPipeClassDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<CommandPipeDiameter> GetByIdPipeDiameter(int id)
        {
            GetPipeDiameterDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandPipeClass>> GetAll()
        {
            GetPipeClasssListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExportPipeClass(string type)
        {
            ExportPipeClasssQuery export = new();
            export.Type = type;
            return await mediator.Send(export);
        }

        public async Task<ExportBaseResponse> GetFiletoExportPipeDiameter(string type)
        {
            ExportPipeDiametersQuery export = new();
            export.Type = type;
            return await mediator.Send(export);
        }
    }
}
