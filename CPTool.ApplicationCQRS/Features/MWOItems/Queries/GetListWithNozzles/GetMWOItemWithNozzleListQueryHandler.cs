using AutoMapper;
using Azure.Core;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Queries.GetListWithNozzles
{
    public class GetMWOItemWithNozzleListQueryHandler : IRequestHandler<GetMWOItemWithNozzlesListItemQuery, List<CommandMWOItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOItemWithNozzleListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWOItem>> Handle(GetMWOItemWithNozzlesListItemQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<MWOItem, bool>> predicate = null!;
            if (request.ModelId == 0)
            {
                predicate = x =>
                   x.MWOId == request.MWOId &&
                   (x.ChapterId == 4 || x.ChapterId == 6 || x.ChapterId == 7) 
                   && x!.Nozzles!.Any(y => y.StreamType == request.type && y.ConnectedTo == null);
            }
            else
            {
                predicate = x =>
                   x.MWOId == request.MWOId &&
                   (x.ChapterId == 4 || x.ChapterId == 6 || x.ChapterId == 7) 
                   && x.Id != request.ModelId && x!.Nozzles!.Any(y =>
                    y.StreamType == request.type && (y.ConnectedTo == null || y.ConnectedTo.Id == request.ModelId));

            }
            IReadOnlyCollection<MWOItem> allMWOItem = await _UnitOfWork.RepositoryMWOItemWithNozzles.GetAllAsync(predicate);




            var result = _mapper.Map<List<CommandMWOItem>>(allMWOItem);

            //if (request.ModelId == 0)
            //    result = result.Select(x => x).Where(z => z!.Nozzles!.Any(y => y.StreamType == request.type && y.ConnectedTo == null)).ToList();
            //else
            //    result = result.Select(x => x).Where(z => z.Id != request.ModelId && z!.Nozzles!.Any(y =>
            //    y.StreamType == request.type && (y.ConnectedTo == null || y.ConnectedTo.Id == request.ModelId))).ToList();

            return result;
        }

    }
}
