using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.PropertySpecifications.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface IPropertySpecificationService
    {
        Task<DeletePropertySpecificationCommandResponse> Delete(int id);
        Task<PropertySpecificationCommandResponse> AddUpdate(CommandPropertySpecification command);

        Task<CommandPropertySpecification> GetById(int id);

        Task<List<CommandPropertySpecification>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandPropertySpecification> List);
       
    }
    public class PropertySpecificationService : IPropertySpecificationService
    {
        protected readonly IMediator mediator;

        public PropertySpecificationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeletePropertySpecificationCommandResponse> Delete(int id)
        {
            DeletePropertySpecificationCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<PropertySpecificationCommandResponse> AddUpdate(CommandPropertySpecification command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandPropertySpecification> GetById(int id)
        {
            GetPropertySpecificationDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandPropertySpecification>> GetAll(int MWOItemId)
        {
            GetPropertySpecificationsListQuery command = new()
            {
                MWOItemId = MWOItemId,
            };
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandPropertySpecification> List)
        {
            ExportPropertySpecificationsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

       
    }
}
