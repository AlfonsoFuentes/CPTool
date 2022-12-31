
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Queries.Export;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.MWOs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public class MWODialogData
    {
        public List<CommandMWOType> MWOTypes { get; set; } = new();
      
    }
    public interface IMWOService
    {
        Task<DeleteMWOCommandResponse> Delete(int id);
        Task<MWOCommandResponse> AddUpdate(CommandMWO command);

        Task<CommandMWO> GetById(int id);

        Task<List<CommandMWO>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type);
        Task<MWODialogData> GetMWODataDialog();
    }
    public class MWOService : IMWOService
    {
        protected readonly IMediator mediator;

        public MWOService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteMWOCommandResponse> Delete(int id)
        {
            DeleteMWOCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<MWOCommandResponse> AddUpdate(CommandMWO command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandMWO> GetById(int id)
        {
            GetMWODetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandMWO>> GetAll()
        {
            GetMWOsListQuery command = new();
            command.IsMainScreenList = true;
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportMWOsQuery export = new();
            export.Type = type;
            return await mediator.Send(export);

        }

        public async Task<MWODialogData> GetMWODataDialog()
        {
            MWODialogData data = new();

            GetMWOTypesListQuery getlist = new();
            data.MWOTypes = await mediator.Send(getlist);

            return data;
        }
    }
}
