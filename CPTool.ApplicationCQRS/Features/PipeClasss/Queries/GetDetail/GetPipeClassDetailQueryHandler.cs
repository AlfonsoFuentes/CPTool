using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetDetail
{
    public class GetPipeClassDetailQueryHandler : IRequestHandler<GetPipeClassDetailQuery, CommandPipeClass>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeClassDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPipeClass> Handle(GetPipeClassDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPipeClass.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPipeClass>(table);
            return dto;
        }
    }
}
