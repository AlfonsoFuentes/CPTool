using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Queries.Specification
{
    public class SearchEquipmentItemSpecification : Specification<EquipmentItem>
    {
        public SearchEquipmentItemSpecification(CommandEquipmentItem query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.EquipmentItem.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.EquipmentItem))
            //{
            //    And(x => x.EquipmentItem == query.EquipmentItem);
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
