namespace CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit
{
    internal class AddEditPaintingItemCommandHandler : IRequestHandler<AddEditPaintingItemCommand, Result<AddEditPaintingItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPaintingItemCommand> _logger;

        public AddEditPaintingItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPaintingItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPaintingItemCommand>> Handle(AddEditPaintingItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PaintingItem>(command);

                _unitOfWork.Repository<PaintingItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPaintingItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PaintingItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PaintingItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPaintingItemCommand), typeof(PaintingItem));

                    _unitOfWork.Repository<PaintingItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPaintingItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PaintingItem)}");
                }
                else
                {
                    return await Result<AddEditPaintingItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPaintingItemCommandValidator : AbstractValidator<AddEditPaintingItemCommand>
    {
        public AddEditPaintingItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
