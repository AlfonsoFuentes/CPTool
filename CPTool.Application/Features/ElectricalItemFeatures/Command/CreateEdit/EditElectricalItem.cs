namespace CPTool.Application.Features.ElectricalItemFeatures.CreateEdit
{
    public class EditElectricalItem : EditCommand
    {



    }
    //internal class AddEditElectricalItemHandler : IRequestHandler<AddEditElectricalItem, Result<AddEditElectricalItem>>
    //{
    //    private IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    private readonly IEmailService _emailService;
    //    private readonly ILogger<AddEditElectricalItem> _logger;

    //    public AddEditElectricalItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditElectricalItem> logger)
    //    {
    //        _unitOfWork = unitofwork;
    //        _mapper = mapper;
    //        _emailService = emailService;
    //        _logger = logger;
    //    }

    //    public async Task<Result<AddEditElectricalItem>> Handle(AddEditElectricalItem command, CancellationToken cancellationToken)
    //    {
          

    //        if (command.Id== 0)
    //        {
                
    //            var table = _mapper.Map<ElectricalItem>(command);

    //            _unitOfWork.Repository<ElectricalItem>().Add(table);
    //            await _unitOfWork.Complete();
    //           command.Id= table.Id;
    //            return await Result<AddEditElectricalItem>.SuccessAsync(command, $"{table.Name} Added to {nameof(ElectricalItem)}");
    //        }
    //        else
    //        {
    //            var table = await _unitOfWork.Repository<ElectricalItem>().GetByIdAsync(command.Id);
    //            if (table != null)
    //            {
    //                _mapper.Map(command, table, typeof(AddEditElectricalItem), typeof(ElectricalItem));

    //                _unitOfWork.Repository<ElectricalItem>().Update(table);
    //                await _unitOfWork.Complete();
    //                return await Result<AddEditElectricalItem>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ElectricalItem)}");
    //            }
    //            else
    //            {
    //                return await Result<AddEditElectricalItem>.FailAsync($"{command.Name} not found");
    //            }
    //        }
    //    }
    //}
    //public class AddEditElectricalItemValidator : AbstractValidator<AddEditElectricalItem>
    //{
    //    public AddEditElectricalItemValidator()
    //    {
    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Not empty")
    //            .NotNull().WithMessage("Not null")
    //            .MaximumLength(50).WithMessage("Max 50 characters");

          

    //    }
    //}
}
