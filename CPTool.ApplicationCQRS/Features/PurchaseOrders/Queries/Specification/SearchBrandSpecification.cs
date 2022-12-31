using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Queries.Specification
{
    public class SearchPurchaseOrderSpecification : Specification<PurchaseOrder>
    {
        public SearchPurchaseOrderSpecification(CommandPurchaseOrder query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.PurchaseOrder.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.PurchaseOrder))
            //{
            //    And(x => x.PurchaseOrder == query.PurchaseOrder);
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
