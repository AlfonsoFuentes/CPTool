using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.Specification
{
    public class SearchPipeDiameterSpecification : Specification<PipeDiameter>
    {
        public SearchPipeDiameterSpecification(CommandPipeDiameter query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.PipeDiameter.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.PipeDiameter))
            //{
            //    And(x => x.PipeDiameter == query.PipeDiameter);
            //}
            //if (query.MinPrice is not null)
            //{
            //    And(x => x.Price >= query.MinPrice);
            //}
            //if (query.MaxPrice is not null)
            //{
            //    And(x => x.Price <= query.MaxPrice);
            //}
        }
    }
}
