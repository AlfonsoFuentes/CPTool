using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Queries.Specification
{
    public class SearchEngineeringCostItemSpecification : Specification<EngineeringCostItem>
    {
        public SearchEngineeringCostItemSpecification(CommandEngineeringCostItem query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.EngineeringCostItem.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.EngineeringCostItem))
            //{
            //    And(x => x.EngineeringCostItem == query.EngineeringCostItem);
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
