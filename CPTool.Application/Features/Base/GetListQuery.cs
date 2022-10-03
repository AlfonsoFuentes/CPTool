using System.Xml.Linq;

namespace CPTool.Application.Features.Base
{
    public class GetListQuery
    {
        public virtual bool FilterFunc(AddEditCommand element, string searchString)
        {

           
            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;


        }
        
    }
}
