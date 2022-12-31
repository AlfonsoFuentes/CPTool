
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetList;
using MediatR;

namespace CPTool.UIApp.Services
{
    public interface ITaxCodeLPService
    {
        Task<DeleteTaxCodeLPCommandResponse> Delete(int id);
        Task<TaxCodeLPCommandResponse> AddUpdate(CommandTaxCodeLP command);

        Task<CommandTaxCodeLP> GetById(int id);

        Task<List<CommandTaxCodeLP>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type);
    }
    public class TaxCodeLPService : ITaxCodeLPService
    {
        protected readonly IMediator mediator;

        public TaxCodeLPService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteTaxCodeLPCommandResponse> Delete(int id)
        {
            DeleteTaxCodeLPCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<TaxCodeLPCommandResponse> AddUpdate(CommandTaxCodeLP command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandTaxCodeLP> GetById(int id)
        {
            GetTaxCodeLPDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandTaxCodeLP>> GetAll()
        {
            GetTaxCodeLPsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportTaxCodeLPsQuery export = new();
            export.Type = type;
            return await mediator.Send(export);

        }
    }
}
