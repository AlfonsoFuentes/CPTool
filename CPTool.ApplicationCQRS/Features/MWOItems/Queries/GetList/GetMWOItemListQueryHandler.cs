using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using System.Diagnostics;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList
{
    public class GetMWOItemListQueryHandler : IRequestHandler<GetMWOItemsListQuery, List<CommandMWOItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWOItem>> Handle(GetMWOItemsListQuery request, CancellationToken cancellationToken)
        {

            Func<IQueryable<MWOItem>, IOrderedQueryable<MWOItem>> orderBy = x => x.OrderBy(x => x.ChapterId).ThenBy(x=>x.TagNumber);

            var allMWOItem = (await _UnitOfWork.RepositoryMWOItem.GetAllAsync(x => x.MWOId == request.MWOId && x.BudgetItem == request.Budget, orderBy));



            var result = _mapper.Map<List<CommandMWOItem>>(allMWOItem);


            return result;
        }

    }

}
