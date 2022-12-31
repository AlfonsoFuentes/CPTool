using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Queries.Specification
{
    public class SearchPaintingItemSpecification : Specification<PaintingItem>
    {
        public SearchPaintingItemSpecification(CommandPaintingItem query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.PaintingItem.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.PaintingItem))
            //{
            //    And(x => x.PaintingItem == query.PaintingItem);
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
