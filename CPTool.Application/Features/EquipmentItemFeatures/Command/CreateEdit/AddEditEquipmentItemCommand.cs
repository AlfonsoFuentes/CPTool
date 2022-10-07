





using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit
{
    public class AddEditEquipmentItemCommand : AddEditCommand, IRequest<Result<AddEditEquipmentItemCommand>>
    {
        public List<AddEditNozzleCommand> NozzlesCommand { get; set; } = new();
       
        public AddEditProcessConditionCommand ProcessConditionCommand { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand == null ? null : ProcessConditionCommand.Id;
        public AddEditProcessFluidCommand? ProcessFluidCommand { get; set; }
      
        public int? GasketId => GasketCommand == null ? null : GasketCommand.Id;
        public AddEditGasketCommand? GasketCommand { get; set; } = null!;
        public int? eInnerMaterialId => eInnerMaterialCommand == null ? null : eInnerMaterialCommand.Id;
        public AddEditMaterialCommand? eInnerMaterialCommand { get; set; } = null!;
        public int? eOuterMaterialId => eOuterMaterialCommand == null ? null : eOuterMaterialCommand.Id;
        public AddEditMaterialCommand? eOuterMaterialCommand { get; set; } = null!;
        public int? EquipmentTypeId => EquipmentTypeCommand == null ? null : EquipmentTypeCommand.Id;
        public AddEditEquipmentTypeCommand? EquipmentTypeCommand { get; set; } = null!;
        public int? EquipmentTypeSubId => EquipmentTypeSubCommand == null ? null : EquipmentTypeSubCommand.Id;
        public AddEditEquipmentTypeSubCommand? EquipmentTypeSubCommand { get; set; } = null!;
        public int? BrandId => BrandCommand == null ? null : BrandCommand.Id;
        public AddEditBrandCommand? BrandCommand { get; set; } = null!;
        public int? SupplierId => SupplierCommand == null ? null : SupplierCommand.Id;
        public AddEditSupplierCommand? SupplierCommand { get; set; } = null!;
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId { get; set; } = "";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditEquipmentItemCommandHandler : IRequestHandler<AddEditEquipmentItemCommand, Result<AddEditEquipmentItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditEquipmentItemCommand> _logger;

        public AddEditEquipmentItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditEquipmentItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditEquipmentItemCommand>> Handle(AddEditEquipmentItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<EquipmentItem>(command);

                _unitOfWork.Repository<EquipmentItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditEquipmentItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(EquipmentItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<EquipmentItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditEquipmentItemCommand), typeof(EquipmentItem));

                    _unitOfWork.Repository<EquipmentItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditEquipmentItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(EquipmentItem)}");
                }
                else
                {
                    return await Result<AddEditEquipmentItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditEquipmentItemCommandValidator : AbstractValidator<AddEditEquipmentItemCommand>
    {
        public AddEditEquipmentItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
