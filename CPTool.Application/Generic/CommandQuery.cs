

using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CPTool.Application.Generic
{
    public class CommandQuery<TEdit> : ICommandQuery<TEdit> where TEdit : EditCommand
    {
        protected readonly IMediator Mediator;
   
        protected DeleteCommand<TEdit> DeleteCommand = new();
        protected QueryList<TEdit> queryList = new();
        protected QueryId<TEdit> QueryId = new();
        protected QueryExcel<TEdit> queryexcel = new();

        public CommandQuery(IMediator mediator)
        {
            TableName = typeof(TEdit).Name;
            TableName = TableName.Substring(4);
            Mediator = mediator;


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
        public async Task<IResult> AddUpdate(TEdit request)
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
        public string FileName { get; set; } = "";
        public void Reset()
        {
        }

        public async Task<Result<QueryExcel<TEdit>>> ExportToExcel(List<TEdit> elements, string filename = "")
        {
            queryexcel.FileName = filename;
            queryexcel.Elements = elements;
            var result = await Mediator.Send(queryexcel);
            FileName = queryexcel.FileName;
            return await Result<QueryExcel<TEdit>>.SuccessAsync(result);
        }
        public List<TEdit> Search(string searched, List<TEdit> result)
        {

            var properties = typeof(TEdit).GetProperties();
            var propertiesAtributes = properties
                .Where(x => Attribute.IsDefined(x, typeof(ReportAttribute)))
                .Select(x => x).ToList();

            foreach (var prop in propertiesAtributes)
            {
                try
                {
                    var any = result.Any(x => x!.GetType()!.GetProperty(prop!.Name)!.GetValue(x!)!.ToString()!.ToLower().Contains(searched.ToLower()));
                    if (any)
                    {
                        result = result.Where(x => x!.GetType()!.GetProperty(prop!.Name)!.GetValue(x!)!.ToString()!.ToLower().Contains(searched.ToLower())).ToList();
                    }

                }
                catch (Exception ex)
                {
                    string exm = ex.Message;
                }


            }


            return result;
        }


        public async Task<List<TEdit>> Get(Expression<Func<TEdit, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

}
