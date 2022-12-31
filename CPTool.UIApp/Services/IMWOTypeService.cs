
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOTypes.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList;
using CPTool.ApplicationCQRSResponses;
using MediatR;

namespace CPTool.UIApp.Services
{

    public interface IMWOTypeService
    {
        Task<DeleteMWOTypeCommandResponse> Delete(int id);
        Task<MWOTypeCommandResponse> AddUpdate(CommandMWOType command);

        Task<CommandMWOType> GetById(int id);

        Task<List<CommandMWOType>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type);
    }
    public class MWOTypeService : IMWOTypeService
    {
        protected readonly IMediator mediator;
       
        public MWOTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteMWOTypeCommandResponse> Delete(int id)
        {
            DeleteMWOTypeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno= await mediator.Send(deletecommand);
           
            return retorno;
          
        }

        public async Task<MWOTypeCommandResponse> AddUpdate(CommandMWOType command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandMWOType> GetById(int id)
        {
            GetMWOTypeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandMWOType>> GetAll()
        {
            GetMWOTypesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportMWOTypesQuery  export = new();
            export.Type = type;
            return await mediator.Send(export);
            
        }
    }
   
}
