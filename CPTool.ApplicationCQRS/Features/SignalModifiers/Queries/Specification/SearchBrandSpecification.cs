using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.Specification
{
    public class SearchSignalModifierSpecification : Specification<SignalModifier>
    {
        public SearchSignalModifierSpecification(CommandSignalModifier query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.SignalModifier.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.SignalModifier))
            //{
            //    And(x => x.SignalModifier == query.SignalModifier);
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
