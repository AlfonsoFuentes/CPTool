
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Queries.Export;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Queries.Export;

using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.EquipmentTypes.Commands.Delete;

using CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public interface IEquipmentTypeService
    {
        Task<DeleteEquipmentTypeCommandResponse> DeleteEquipment(int id);
        Task<DeleteEquipmentTypeSubCommandResponse> DeleteEquipmentSub(int id);
        Task<EquipmentTypeCommandResponse> AddUpdateEquipment(CommandEquipmentType command);
        Task<EquipmentTypeSubCommandResponse> AddUpdateEquipmentSub(CommandEquipmentTypeSub command);
        Task<CommandEquipmentType> GetByIdEquipment(int id);
        Task<CommandEquipmentTypeSub> GetByIdEquipmentSub(int id);
        Task<List<CommandEquipmentTypeSub>> GetByEquipmentSubByEquipmenType(int equipmentypeid);
        Task<List<CommandEquipmentType>> GetAll();
 
        Task<ExportBaseResponse> GetFiletoExportEquipment(string type, List<CommandEquipmentType> List);
        Task<ExportBaseResponse> GetFiletoExportEquipmentSub(string type, List<CommandEquipmentTypeSub> List);
    }

        public class EquipmentTypeService : IEquipmentTypeService
    {
        protected readonly IMediator mediator;

      

        public EquipmentTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteEquipmentTypeCommandResponse> DeleteEquipment(int id)
        {
            DeleteEquipmentTypeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;
        }

        public async Task<DeleteEquipmentTypeSubCommandResponse> DeleteEquipmentSub(int id)
        {
            DeleteEquipmentTypeSubCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;
        }

        public async Task<EquipmentTypeCommandResponse> AddUpdateEquipment(CommandEquipmentType command)
        {
            return await mediator.Send(command);
        }

        public async Task<EquipmentTypeSubCommandResponse> AddUpdateEquipmentSub(CommandEquipmentTypeSub command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandEquipmentType> GetByIdEquipment(int id)
        {
            GetEquipmentTypeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<CommandEquipmentTypeSub> GetByIdEquipmentSub(int id)
        {
            GetEquipmentTypeSubDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandEquipmentType>> GetAll()
        {
            GetEquipmentTypesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExportEquipment(string type, List<CommandEquipmentType> List)
        {
            ExportEquipmentTypesQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);
        }

        public async Task<ExportBaseResponse> GetFiletoExportEquipmentSub(string type, List<CommandEquipmentTypeSub> List)
        {
            ExportEquipmentTypeSubsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);
        }

        public async Task<List<CommandEquipmentTypeSub>> GetByEquipmentSubByEquipmenType(int equipmentypeid)
        {
            GetEquipmentTypeSubsListQuery command = new()
            {
                EquipmentTypeId = equipmentypeid
            };
            return await mediator.Send(command);
        }
    }
}
