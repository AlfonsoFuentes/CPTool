
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Materials.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Materials.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IMaterialsService
    {
        Task<DeleteMaterialCommandResponse> Delete(int id);
        Task<MaterialCommandResponse> AddUpdate(CommandMaterial command);

        Task<CommandMaterial> GetById(int id);

        Task<List<CommandMaterial>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandMaterial> List);
    }
    public class MaterialsService : IMaterialsService
    {
        protected readonly IMediator mediator;

        public MaterialsService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteMaterialCommandResponse> Delete(int id)
        {
            DeleteMaterialCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<MaterialCommandResponse> AddUpdate(CommandMaterial command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandMaterial> GetById(int id)
        {
            GetMaterialDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandMaterial>> GetAll()
        {
            GetMaterialsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandMaterial> List)
        {
            ExportMaterialsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
