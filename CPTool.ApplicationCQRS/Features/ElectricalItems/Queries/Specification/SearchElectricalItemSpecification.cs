using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Queries.Specification
{
    public class SearchElectricalItemSpecification : Specification<ElectricalItem>
    {
        public SearchElectricalItemSpecification(CommandElectricalItem query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.ElectricalItem.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.ElectricalItem))
            //{
            //    And(x => x.ElectricalItem == query.ElectricalItem);
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
