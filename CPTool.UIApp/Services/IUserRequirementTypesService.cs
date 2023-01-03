
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public interface IUserRequirementTypeService
    {
        Task<DeleteUserRequirementTypeCommandResponse> Delete(int id);
        Task<UserRequirementTypeCommandResponse> AddUpdate(CommandUserRequirementType command);

        Task<CommandUserRequirementType> GetById(int id);

        Task<List<CommandUserRequirementType>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUserRequirementType> List);
    }
    public class UserRequirementTypeService : IUserRequirementTypeService
    {
        protected readonly IMediator mediator;

        public UserRequirementTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteUserRequirementTypeCommandResponse> Delete(int id)
        {
            DeleteUserRequirementTypeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<UserRequirementTypeCommandResponse> AddUpdate(CommandUserRequirementType command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandUserRequirementType> GetById(int id)
        {
            GetUserRequirementTypeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandUserRequirementType>> GetAll()
        {
            GetUserRequirementTypesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUserRequirementType> List)
        {
            ExportUserRequirementTypesQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
