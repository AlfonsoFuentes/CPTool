
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirements.Queries.Export;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.UserRequirements.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public class UserRequirementDialogData
    {
        public List<CommandUser> Users = new();
        public List<CommandUserRequirementType> UserRequirmentTypes = new();
    }
    public interface IUserRequirementService
    {
        Task<DeleteUserRequirementCommandResponse> Delete(int id);
        Task<UserRequirementCommandResponse> AddUpdate(CommandUserRequirement command);

        Task<CommandUserRequirement> GetById(int id);

        Task<List<CommandUserRequirement>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUserRequirement> List);
        Task<UserRequirementDialogData> GetDialogData();
    }
    public class UserRequirementService : IUserRequirementService
    {
        protected readonly IMediator mediator;

        public UserRequirementService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteUserRequirementCommandResponse> Delete(int id)
        {
            DeleteUserRequirementCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<UserRequirementCommandResponse> AddUpdate(CommandUserRequirement command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandUserRequirement> GetById(int id)
        {
            GetUserRequirementDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandUserRequirement>> GetAll(int MWOId)
        {
            GetUserRequirementsListQuery command = new()
            {
                MWOId = MWOId,
            };
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUserRequirement> List)
        {
            ExportUserRequirementsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<UserRequirementDialogData> GetDialogData()
        {
            UserRequirementDialogData response = new();

            GetUsersListQuery getusers = new();
            response.Users=await mediator.Send(getusers);

            GetUserRequirementTypesListQuery gettypes = new();
            response.UserRequirmentTypes =await mediator.Send(gettypes);
            return response;
        }
    }
}
