
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FieldLocations.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.FieldLocations.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public interface IFieldLocationService
    {
        Task<DeleteFieldLocationCommandResponse> Delete(int id);
        Task<FieldLocationCommandResponse> AddUpdate(CommandFieldLocation command);

        Task<CommandFieldLocation> GetById(int id);

        Task<List<CommandFieldLocation>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandFieldLocation> List);
    }
    public class FieldLocationService : IFieldLocationService
    {
        protected readonly IMediator mediator;

        public FieldLocationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteFieldLocationCommandResponse> Delete(int id)
        {
            DeleteFieldLocationCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<FieldLocationCommandResponse> AddUpdate(CommandFieldLocation command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandFieldLocation> GetById(int id)
        {
            GetFieldLocationDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandFieldLocation>> GetAll()
        {
            GetFieldLocationsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandFieldLocation> List)
        {
            ExportFieldLocationsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
