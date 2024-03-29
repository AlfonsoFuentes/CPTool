﻿using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetList;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetList
{
    public class GetUserRequirementListQueryHandler : IRequestHandler<GetUserRequirementsListQuery, List<CommandUserRequirement>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserRequirementListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandUserRequirement>> Handle(GetUserRequirementsListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<UserRequirement, bool>> predicate = request.MWOId == 0 ? x => x.MWOId != 0 : x => x.MWOId ==  request.MWOId;
            Func<IQueryable<UserRequirement>, IOrderedQueryable<UserRequirement>> orderBy = y => y.OrderBy(z => z.UserRequirementTypeId);
            var allUserRequirement = (await _UnitOfWork.RepositoryUserRequirement.GetAllAsync(predicate, orderBy));
            return _mapper.Map<List<CommandUserRequirement>>(allUserRequirement);
        }
    }
}
