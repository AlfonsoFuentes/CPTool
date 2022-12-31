using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList
{
    public class GetPipeClassListQueryHandler : IRequestHandler<GetPipeClasssListQuery, List<CommandPipeClass>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeClassListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPipeClass>> Handle(GetPipeClasssListQuery request, CancellationToken cancellationToken)
        {
            var allPipeClass = (await _UnitOfWork.RepositoryPipeClass.GetAllAsync());

            var retorno= _mapper.Map<List<CommandPipeClass>>(allPipeClass);
            return retorno;
        }
    }
}
