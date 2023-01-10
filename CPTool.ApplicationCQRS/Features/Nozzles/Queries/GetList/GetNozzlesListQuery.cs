using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetList
{
    public class GetNozzlesListQuery : IRequest<List<CommandNozzle>>
    {
       
        public int MWOItemId { get; set; }    
      
    }
}
