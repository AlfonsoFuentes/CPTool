
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetList;

using MediatR;

namespace CPTool.UIApp.Services
{
    public interface IUnitaryBasePrizeService
    {
        Task<DeleteUnitaryBasePrizeCommandResponse> Delete(int id);
        Task<UnitaryBasePrizeCommandResponse> AddUpdate(CommandUnitaryBasePrize command);

        Task<CommandUnitaryBasePrize> GetById(int id);

        Task<List<CommandUnitaryBasePrize>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type);
    }
    public class UnitaryBasePrizeService : IUnitaryBasePrizeService
    {
        protected readonly IMediator mediator;

        public UnitaryBasePrizeService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteUnitaryBasePrizeCommandResponse> Delete(int id)
        {
            DeleteUnitaryBasePrizeCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<UnitaryBasePrizeCommandResponse> AddUpdate(CommandUnitaryBasePrize command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandUnitaryBasePrize> GetById(int id)
        {
            GetUnitaryBasePrizeDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandUnitaryBasePrize>> GetAll()
        {
            GetUnitaryBasePrizesListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportUnitaryBasePrizesQuery export = new();
            export.Type = type;
            return await mediator.Send(export);

        }
    }
}
