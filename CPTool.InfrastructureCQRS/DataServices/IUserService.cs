
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Users.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IUserService
    {
        Task<DeleteUserCommandResponse> Delete(int id);
        Task<UserCommandResponse> AddUpdate(CommandUser command);

        Task<CommandUser> GetById(int id);

        Task<List<CommandUser>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUser> List);
    }
    public class UserService : IUserService
    {
        protected readonly IMediator mediator;

        public UserService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteUserCommandResponse> Delete(int id)
        {
            DeleteUserCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<UserCommandResponse> AddUpdate(CommandUser command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandUser> GetById(int id)
        {
            GetUserDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandUser>> GetAll()
        {
            GetUsersListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandUser> List)
        {
            ExportUsersQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
