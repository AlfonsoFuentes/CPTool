namespace CPTool.Application.Features.FoundationItemFeatures.CreateEdit
{
    public class EditFoundationItem : EditCommand
    {



    }
    //internal class AddEditFoundationItemHandler : IRequestHandler<AddEditFoundationItem, Result<AddEditFoundationItem>>
    //{
    //    private IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    private readonly IEmailService _emailService;
    //    private readonly ILogger<AddEditFoundationItem> _logger;

    //    public AddEditFoundationItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditFoundationItem> logger)
    //    {
    //        _unitOfWork = unitofwork;
    //        _mapper = mapper;
    //        _emailService = emailService;
    //        _logger = logger;
    //    }

    //    public async Task<Result<AddEditFoundationItem>> Handle(AddEditFoundationItem command, CancellationToken cancellationToken)
    //    {
          

    //        if (command.Id== 0)
    //        {
                
    //            var table = _mapper.Map<FoundationItem>(command);

    //            _unitOfWork.Repository<FoundationItem>().Add(table);
    //            await _unitOfWork.Complete();
    //           command.Id= table.Id;
    //            return await Result<AddEditFoundationItem>.SuccessAsync(command, $"{table.Name} Added to {nameof(FoundationItem)}");
    //        }
    //        else
    //        {
    //            var table = await _unitOfWork.Repository<FoundationItem>().GetByIdAsync(command.Id);
    //            if (table != null)
    //            {
    //                _mapper.Map(command, table, typeof(AddEditFoundationItem), typeof(FoundationItem));

    //                _unitOfWork.Repository<FoundationItem>().Update(table);
    //                await _unitOfWork.Complete();
    //                return await Result<AddEditFoundationItem>.SuccessAsync(command, $"{table.Name} Updated in {nameof(FoundationItem)}");
    //            }
    //            else
    //            {
    //                return await Result<AddEditFoundationItem>.FailAsync($"{command.Name} not found");
    //            }
    //        }
    //    }
    //}
    //public class AddEditFoundationItemValidator : AbstractValidator<AddEditFoundationItem>
    //{
    //    public AddEditFoundationItemValidator()
    //    {
    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Not empty")
    //            .NotNull().WithMessage("Not null")
    //            .MaximumLength(50).WithMessage("Max 50 characters");

          

    //    }
    //}
}
