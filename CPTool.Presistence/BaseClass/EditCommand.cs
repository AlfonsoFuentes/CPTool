
using System.Net;

namespace CPTool.Persistence.BaseClass
{
    public class EditCommand : IRequest<Result<int>>
    {


        [Report(Order = 1)]
        public int Id { get; set; }
        [Report(Order = 2)]
        public virtual string Name { get; set; } = string.Empty;
        public string Descrtpion { get; set; } = string.Empty;
    }

}
