

namespace CPTool.Application.Features.Base
{
    public  class EditBaseHandler<TEdit, TEntity> where TEdit : EditCommand where TEntity : BaseDomainModel
    {
        protected IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IEmailService _emailService;
        protected readonly ILogger<TEdit> _logger;

        public EditBaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<TEdit> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public virtual async Task<Result<int>> Handle(TEdit command, CancellationToken cancellationToken)
        {

            var table = await _unitOfWork.Repository<TEntity>().GetByIdAsync(command.Id);
            if (table != null)
            {
                try
                {
                    _mapper.Map(command, table, typeof(TEdit), typeof(TEntity));

                    _unitOfWork.Repository<TEntity>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Updated in {nameof(TEntity)}");
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
            else
            {
                return await Result<int>.FailAsync($"{command.Name} not found");
            }
        }
        
       
    }
}
