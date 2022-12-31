using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Users.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Users.Queries.GetList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUsersListQuery, List<CommandUser>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandUser>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var allUser = (await _UnitOfWork.RepositoryUser.GetAllAsync());
            return _mapper.Map<List<CommandUser>>(allUser);
        }
    }
}
