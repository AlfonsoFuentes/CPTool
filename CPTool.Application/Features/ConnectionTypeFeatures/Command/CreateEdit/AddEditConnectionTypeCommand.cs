





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit
{
    public class AddEditConnectionTypeCommand : AddEditCommand, IRequest<Result<AddEditConnectionTypeCommand>>
    {
        public List<AddEditNozzleCommand> NozzlesCommand { get; set; } = new();

       
    }
    internal class AddEditConnectionTypeCommandHandler : IRequestHandler<AddEditConnectionTypeCommand, Result<AddEditConnectionTypeCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditConnectionTypeCommand> _logger;

        public AddEditConnectionTypeCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditConnectionTypeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditConnectionTypeCommand>> Handle(AddEditConnectionTypeCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<ConnectionType>(command);

                _unitOfWork.Repository<ConnectionType>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditConnectionTypeCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(ConnectionType)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<ConnectionType>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditConnectionTypeCommand), typeof(ConnectionType));

                    _unitOfWork.Repository<ConnectionType>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditConnectionTypeCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ConnectionType)}");
                }
                else
                {
                    return await Result<AddEditConnectionTypeCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditConnectionTypeCommandValidator : AbstractValidator<AddEditConnectionTypeCommand>
    {
        public AddEditConnectionTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
