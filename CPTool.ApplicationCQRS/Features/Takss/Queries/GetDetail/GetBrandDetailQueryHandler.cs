using AutoMapper;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Takss.Queries.GetDetail
{
    public class GetTaksDetailQueryHandler : IRequestHandler<GetTaksDetailQuery, CommandTaks>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaksDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandTaks> Handle(GetTaksDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryTaks.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandTaks>(table);
            return dto;
        }
    }
}
