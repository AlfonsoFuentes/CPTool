

using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentTypeFeatures.Command.CreateEdit
{
    public class AddEditEquipmentTypeCommand : AddEditCommand, IRequest<Result<AddEditEquipmentTypeCommand>>
    {

        public string TagLetter { get; set; } = string.Empty;

        public List<AddEditEquipmentItemCommand> EquipmentItemsCommand { get; set; } = new();
        public List<AddEditEquipmentTypeSubCommand>? EquipmentTypesSubCommand { get; set; } = new();

       

    }
    internal class AddEditEquipmentTypeCommandHandler : IRequestHandler<AddEditEquipmentTypeCommand, Result<AddEditEquipmentTypeCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditEquipmentTypeCommand> _logger;

        public AddEditEquipmentTypeCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditEquipmentTypeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditEquipmentTypeCommand>> Handle(AddEditEquipmentTypeCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {
                var table = _mapper.Map<EquipmentType>(command);

                _unitOfWork.Repository<EquipmentType>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;

                return await Result<AddEditEquipmentTypeCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(EquipmentType)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<EquipmentType>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditEquipmentTypeCommand), typeof(EquipmentType));

                    _unitOfWork.Repository<EquipmentType>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditEquipmentTypeCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(EquipmentType)}");
                }
                else
                {
                    return await Result<AddEditEquipmentTypeCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditEquipmentTypeCommandValidator : AbstractValidator<AddEditEquipmentTypeCommand>
    {
        public AddEditEquipmentTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 10 characters");

            RuleFor(x => x.TagLetter)
          .NotEmpty().WithMessage("Not Empty")
          .MaximumLength(2).WithMessage("Max 2 characters"); ; ;

        }
    }
}
