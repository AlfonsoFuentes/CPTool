using CPtool.ExtensionMethods;
using CPTool.Application.Services;
using System.Reflection;
using System.Xml.Linq;

namespace CPTool.Application.Generic
{
    public class QueryExcel<T> : IRequest<QueryExcel<T>> where T : EditCommand
    {
        public List<T>? Elements { get; set; }
        public Func<T, bool>? Filter { get; set; }
        public Func<T, bool>? OrderBy { get; set; }
        public string? FileName { get; set; }
        public byte[]? Result { get; set; }
    }
    public class QueryExcelHandler<T> : IRequestHandler<QueryExcel<T>, QueryExcel<T>>
      where T : EditCommand


    {
        protected readonly IExcelService _excelService;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitofwork;
        public QueryExcelHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            IExcelService excelService)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
            _excelService = excelService;
        }
        public virtual async Task<QueryExcel<T>> Handle(QueryExcel<T> request, CancellationToken cancellationToken)
        {
            var elements = request.Elements;
            if (request.Filter != null)
            {
                elements = elements!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                elements = elements!.OrderBy(request.OrderBy).ToList();
            }
            var properties = typeof(T).GetProperties();

            var propertiesReportAtributes = properties
                 .Where(x => Attribute.IsDefined(x, typeof(ReportAttribute)))
                 .Select(x => x)
                 .OrderBy(row => row.GetCustomAttribute<ReportAttribute>()!.Order)
                 .ToList();
            AddObjectProperties(properties);

            var classname = typeof(T).Name.Substring(4);
            if (request.FileName == "") request.FileName = classname;
            request.Result = await _excelService.ExportAsync(elements!,
               Dictionary
               , request.FileName!);

            return request;
        }
        Dictionary<string, Func<T, object?>> Dictionary = new();
        void AddToDictionary(string name, Func<T, object?> func)
        {
            Dictionary.Add(name, func);
        }
        void AddObjectProperties(PropertyInfo[] properties)
        {
           
            var propertiesReportAtributes = properties
                 .Where(x => Attribute.IsDefined(x, typeof(ReportAttribute)))
                 .Select(x => x)
                 .OrderBy(row => row.GetCustomAttribute<ReportAttribute>()!.Order)
                 .ToList();
            foreach (var row in propertiesReportAtributes)
            {

                AddToDictionary(row.Name, item => item.GetType().GetProperty(row.Name)!.GetValue(item));
                if(row.CustomAttributes.Any(x=>x.AttributeType==typeof(ObjectReportAttribute)))
                {
                    var type = row.GetType();
                    var value = type.GetProperties();
                    if (value != null)
                    {
                       
                        AddObjectProperties(value);
                    }
                    
                }


            }
        }
    }
}
