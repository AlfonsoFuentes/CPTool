





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Command.CreateEdit
{
    public class AddEditChapterCommand : AddEditCommand, IRequest<Result<AddEditChapterCommand>>
    {
        public string LetterName=>$"{Letter}-{Name}";
        public string? Letter { get; set; }
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } =new();
    }
    internal class AddEditChapterCommandHandler : IRequestHandler<AddEditChapterCommand, Result<AddEditChapterCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditChapterCommand> _logger;

        public AddEditChapterCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditChapterCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditChapterCommand>> Handle(AddEditChapterCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<Chapter>(command);

                _unitOfWork.Repository<Chapter>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditChapterCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Chapter)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Chapter>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditChapterCommand), typeof(Chapter));

                    _unitOfWork.Repository<Chapter>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditChapterCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Chapter)}");
                }
                else
                {
                    return await Result<AddEditChapterCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditChapterCommandValidator : AbstractValidator<AddEditChapterCommand>
    {
        public AddEditChapterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
