
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Queries.Export;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.ProcessFluids.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public class ProcessFluidsDialogData
    {
        public List<CommandPropertyPackage> PropertyPackages { get; set; }
    }
    public interface IProcessFluidsService
    {
        Task<DeleteProcessFluidCommandResponse> Delete(int id);
        Task<ProcessFluidCommandResponse> AddUpdate(CommandProcessFluid command);

        Task<CommandProcessFluid> GetById(int id);

        Task<List<CommandProcessFluid>> GetAll();

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandProcessFluid> List);
        Task<ProcessFluidsDialogData> GetDataDialog();
    }
    public class ProcessFluidsService : IProcessFluidsService
    {
        protected readonly IMediator mediator;

        public ProcessFluidsService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteProcessFluidCommandResponse> Delete(int id)
        {
            DeleteProcessFluidCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<ProcessFluidCommandResponse> AddUpdate(CommandProcessFluid command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandProcessFluid> GetById(int id)
        {
            GetProcessFluidDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandProcessFluid>> GetAll()
        {
            GetProcessFluidsListQuery command = new();
            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandProcessFluid> List)
        {
            ExportProcessFluidsQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<ProcessFluidsDialogData> GetDataDialog()
        {
            ProcessFluidsDialogData datadialog = new();
            GetPropertyPackagesListQuery querypropertypackage = new();
            datadialog.PropertyPackages=await mediator.Send(querypropertypackage);
            return datadialog;
            
        }
    }
}
