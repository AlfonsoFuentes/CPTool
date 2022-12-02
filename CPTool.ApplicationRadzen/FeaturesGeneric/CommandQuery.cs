using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Text.Encodings.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.ApplicationRadzen.FeaturesGeneric
{
    public class CommandQuery<TEdit> : ICommandQuery<TEdit> where TEdit : EditCommand
    {
        protected readonly IMediator Mediator;
        protected Command<TEdit> Command = new();
        protected DeleteCommand<TEdit> DeleteCommand = new();
        protected QueryList<TEdit> queryList = new();
        protected QueryId<TEdit> QueryId = new();
        private readonly NavigationManager NavigationManager;
        public CommandQuery(IMediator mediator, NavigationManager navigationManager)
        {
            TableName = typeof(TEdit).Name;
            TableName = TableName.Substring(4);
            Mediator = mediator;
            NavigationManager = navigationManager;

        }
        public async Task<List<TEdit>> GetAll()
        {
           
            var result = await Mediator.Send(queryList);
            return result;
        }
        public async Task<TEdit> GetById(int id)
        {
            QueryId.Id = id;
            var result = await Mediator.Send(QueryId);
            return result;
        }
        public async Task<Result<int>> AddUpdate(TEdit request)
        {
            var result = await Mediator.Send(request);

            return result;

        }
        public async Task<IResult> Delete(int id)
        {
            DeleteCommand.Id = id;
            var result = await Mediator.Send(DeleteCommand);

            return result;
        }

        public string TableName { get; set; }
        //public async Task ExportToExcel(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query!.ToUrl($"export/pmtool/{TableName}/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";

        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        //public async Task ExportToCSV(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query.ToUrl($"export/pmtool/{TableName}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";
        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        //public async Task ExportTopdf(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query.ToUrl($"export/pmtool/{TableName}/pdf(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/pdf(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";
        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        public void Reset()
        {
        }

    }
    public class CommandQueryBrandSupplier : ICommandQuery<EditBrandSupplier>
    {
        protected readonly IMediator Mediator;
        protected EditBrandSupplier Command = new();
        protected DeleteCommand<EditBrandSupplier> DeleteCommand = new();
        protected QueryList<EditBrandSupplier> queryList = new();
        protected QueryId<EditBrandSupplier> QueryId = new();
        private readonly NavigationManager NavigationManager;
        public CommandQueryBrandSupplier(IMediator mediator, NavigationManager navigationManager)
        {
            TableName = typeof(EditBrandSupplier).Name;
            TableName = TableName.Substring(4);
            Mediator = mediator;
            NavigationManager = navigationManager;

        }
        public async Task<List<EditBrandSupplier>> GetAll()
        {

            var result = await Mediator.Send(queryList);
            return result;
        }
        public async Task<EditBrandSupplier> GetById(int id)
        {
            QueryId.Id = id;
            var result = await Mediator.Send(QueryId);
            return result;
        }
        public async Task<Result<int>> AddUpdate(EditBrandSupplier request)
        {
            var result = await Mediator.Send(request);

            return result;

        }
        public async Task<IResult> Delete(int id)
        {
            DeleteCommand.Id = id;
            var result = await Mediator.Send(DeleteCommand);

            return result;
        }

        public string TableName { get; set; }
        //public async Task ExportToExcel(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query!.ToUrl($"export/pmtool/{TableName}/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";

        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        //public async Task ExportToCSV(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query.ToUrl($"export/pmtool/{TableName}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";
        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        //public async Task ExportTopdf(QueryFilter query = null!, string filename = null!)
        //{
        //    var query1 = query.ToUrl($"export/pmtool/{TableName}/pdf(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
        //    var query2 = $"export/pmtool/{TableName}/pdf(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";
        //    NavigationManager.NavigateTo(query != null ? query1 : query2, true);
        //}
        public void Reset()
        {

        }

    }

}
