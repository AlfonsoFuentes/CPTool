using AutoMapper;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Users.Queries.GetDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, CommandUser>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandUser> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryUser.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandUser>(table);
            return dto;
        }
    }
}
