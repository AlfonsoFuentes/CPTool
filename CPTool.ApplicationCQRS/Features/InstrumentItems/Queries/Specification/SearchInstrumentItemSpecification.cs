using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Queries.Specification
{
    public class SearchInstrumentItemSpecification : Specification<InstrumentItem>
    {
        public SearchInstrumentItemSpecification(CommandInstrumentItem query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.InstrumentItem.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.InstrumentItem))
            //{
            //    And(x => x.InstrumentItem == query.InstrumentItem);
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
