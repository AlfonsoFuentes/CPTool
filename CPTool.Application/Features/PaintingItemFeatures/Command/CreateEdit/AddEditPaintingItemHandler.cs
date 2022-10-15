namespace CPTool.Application.Features.PaintingItemFeatures.CreateEdit
{
    //internal class AddEditPaintingItemHandler : IRequestHandler<AddEditPaintingItem, Result<AddEditPaintingItem>>
    //{
    //    private IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    private readonly IEmailService _emailService;
    //    private readonly ILogger<AddEditPaintingItem> _logger;

    //    public AddEditPaintingItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPaintingItem> logger)
    //    {
    //        _unitOfWork = unitofwork;
    //        _mapper = mapper;
    //        _emailService = emailService;
    //        _logger = logger;
    //    }

    //    public async Task<Result<AddEditPaintingItem>> Handle(AddEditPaintingItem command, CancellationToken cancellationToken)
    //    {
          

    //        if (command.Id== 0)
    //        {
                
    //            var table = _mapper.Map<PaintingItem>(command);

    //            _unitOfWork.Repository<PaintingItem>().Add(table);
    //            await _unitOfWork.Complete();
    //           command.Id= table.Id;
    //            return await Result<AddEditPaintingItem>.SuccessAsync(command, $"{table.Name} Added to {nameof(PaintingItem)}");
    //        }
    //        else
    //        {
    //            var table = await _unitOfWork.Repository<PaintingItem>().GetByIdAsync(command.Id);
    //            if (table != null)
    //            {
    //                _mapper.Map(command, table, typeof(AddEditPaintingItem), typeof(PaintingItem));

    //                _unitOfWork.Repository<PaintingItem>().Update(table);
    //                await _unitOfWork.Complete();
    //                return await Result<AddEditPaintingItem>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PaintingItem)}");
    //            }
    //            else
    //            {
    //                return await Result<AddEditPaintingItem>.FailAsync($"{command.Name} not found");
    //            }
    //        }
    //    }
    //}
    //public class AddEditPaintingItemValidator : AbstractValidator<AddEditPaintingItem>
    //{
    //    public AddEditPaintingItemValidator()
    //    {
    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Not empty")
    //            .NotNull().WithMessage("Not null")
    //            .MaximumLength(50).WithMessage("Max 50 characters");

          

    //    }
    //}
}
