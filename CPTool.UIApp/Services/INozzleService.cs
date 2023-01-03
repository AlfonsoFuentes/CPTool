
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Queries.Export;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Nozzles.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public class NozzleDialogData
    {
        public List<CommandPipeClass> PipeClasses { get; set; } = new();
        public List<CommandPipeDiameter> PipeDiameters { get; set; } = new();
        public List<CommandConnectionType> ConnectionTypes { get; set; } = new();
        public List<CommandMaterial> Materials { get; set; } = new();
        public List<CommandGasket> Gaskets { get; set; } = new();
        
            
            
            
    }
    public interface INozzleService
    {
        Task<DeleteNozzleCommandResponse> Delete(int id);
        Task<NozzleCommandResponse> AddUpdate(CommandNozzle command);

        Task<CommandNozzle> GetById(int id);

        Task<List<CommandNozzle>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandNozzle> List);
        Task<NozzleDialogData> GetNozzleDataDialog(CommandNozzle command);

        Task<List<CommandPipeDiameter>> GetPipeDiameterByPipeClass(int pipeclassid);
    }
    public class NozzleService : INozzleService
    {
        protected readonly IMediator mediator;

        public NozzleService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteNozzleCommandResponse> Delete(int id)
        {
            DeleteNozzleCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<NozzleCommandResponse> AddUpdate(CommandNozzle command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandNozzle> GetById(int id)
        {
            GetNozzleDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandNozzle>> GetAll()
        {
            GetNozzlesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandNozzle> List)
        {
            ExportNozzlesQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<NozzleDialogData> GetNozzleDataDialog(CommandNozzle command)
        {
            NozzleDialogData result= new();
            
            GetPipeClasssListQuery pipeclass = new();
            result.PipeClasses=await mediator.Send(pipeclass);
            if(command.nPipeClassId!=null)
            {
                result.PipeDiameters = await GetPipeDiameterByPipeClass(command.nPipeClass.Id);
            }

            GetMaterialsListQuery material = new();
            result.Materials=await mediator.Send(material);

            GetGasketsListQuery gasket = new();
            result.Gaskets=await mediator.Send(gasket);

            GetConnectionTypesListQuery connection = new();
            result.ConnectionTypes=await mediator.Send(connection); 
            return result;
        }
        public async Task<List<CommandPipeDiameter>> GetPipeDiameterByPipeClass(int pipeclassid)
        {
            GetPipeDiametersListQuery pipediameter = new()
            { PipeClassId = pipeclassid };
            return await mediator.Send(pipediameter);

        }

    }
}
