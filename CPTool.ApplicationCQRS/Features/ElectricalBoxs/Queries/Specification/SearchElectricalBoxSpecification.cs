﻿using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Queries.Specification
{
    public class SearchElectricalBoxSpecification : Specification<ElectricalBox>
    {
        public SearchElectricalBoxSpecification(CommandElectricalBox query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.ElectricalBox.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.ElectricalBox))
            //{
            //    And(x => x.ElectricalBox == query.ElectricalBox);
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
