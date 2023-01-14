
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public interface ITaxCodeLDService
    {
        Task<DeleteTaxCodeLDCommandResponse> Delete(int id);
        Task<TaxCodeLDCommandResponse> AddUpdate(CommandTaxCodeLD command);

        Task<CommandTaxCodeLD> GetById(int id);

        Task<List<CommandTaxCodeLD>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandTaxCodeLD> List);
    }
    public class TaxCodeLDService : ITaxCodeLDService
    {
        protected readonly IMediator mediator;

        public TaxCodeLDService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteTaxCodeLDCommandResponse> Delete(int id)
        {
            DeleteTaxCodeLDCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<TaxCodeLDCommandResponse> AddUpdate(CommandTaxCodeLD command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandTaxCodeLD> GetById(int id)
        {
            GetTaxCodeLDDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandTaxCodeLD>> GetAll()
        {
            GetTaxCodeLDsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandTaxCodeLD> List)
        {
            ExportTaxCodeLDsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }
    }
}
