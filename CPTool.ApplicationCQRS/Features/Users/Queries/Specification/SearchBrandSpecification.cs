﻿using CPTool.ApplicationCQRS.Common;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Users.Queries.Specification
{
    public class SearchUserSpecification : Specification<User>
    {
        public SearchUserSpecification(CommandUser query)
        {
            Criteria = q => q.Name != null;
            if (!string.IsNullOrEmpty(query.Name))
            {
                //And(x => x.Name.Contains(query.Keyword) || x.Description.Contains(query.Keyword) || x.User.Contains(query.Keyword));
            }
            //if (!string.IsNullOrEmpty(query.Name))
            //{
            //    And(x => x.Name.Contains(query.Name));
            //}
            //if (!string.IsNullOrEmpty(query.Unit))
            //{
            //    And(x => x.Unit == query.Unit);
            //}
            //if (!string.IsNullOrEmpty(query.User))
            //{
            //    And(x => x.User == query.User);
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
