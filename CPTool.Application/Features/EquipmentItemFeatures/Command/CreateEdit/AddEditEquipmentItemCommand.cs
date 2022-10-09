





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
        public int? ProcessConditionId => ProcessConditionCommand?.Id == 0 ? null : ProcessConditionCommand?.Id;
        public AddEditProcessConditionCommand ProcessConditionCommand { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand?.Id==0 ? null : ProcessConditionCommand.Id;
        public AddEditProcessFluidCommand? ProcessFluidCommand { get; set; } = new();

        public int? GasketId => GasketCommand?.Id == 0 ? null : GasketCommand?.Id;
        public AddEditGasketCommand? GasketCommand { get; set; } = new();
        public int? eInnerMaterialId => eInnerMaterialCommand?.Id == 0 ? null : eInnerMaterialCommand?.Id;
        public AddEditMaterialCommand? eInnerMaterialCommand { get; set; } = new();
        public int? eOuterMaterialId => eOuterMaterialCommand?.Id == 0 ? null : eOuterMaterialCommand?.Id;
        public AddEditMaterialCommand? eOuterMaterialCommand { get; set; } = new();
        public int? EquipmentTypeId => EquipmentTypeCommand?.Id == 0 ? null : EquipmentTypeCommand?.Id;
        public AddEditEquipmentTypeCommand? EquipmentTypeCommand { get; set; } = new();
        public int? EquipmentTypeSubId => EquipmentTypeSubCommand?.Id == 0 ? null : EquipmentTypeSubCommand?.Id;
        public AddEditEquipmentTypeSubCommand? EquipmentTypeSubCommand { get; set; } = new();
        public int? BrandId => BrandCommand?.Id==0? null : BrandCommand?.Id;
        public AddEditBrandCommand BrandCommand { get; set; } = new();
        public int? SupplierId => SupplierCommand?.Id == 0 ? null : SupplierCommand?.Id;
        public AddEditSupplierCommand SupplierCommand { get; set; } = new();
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId  => $"{EquipmentTypeCommand?.TagLetter}{EquipmentTypeSubCommand?.TagLetter}-{TagNumber}";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();

        public override T AddDetailtoMaster<T>() 
        {
            if(typeof(T) == typeof(AddEditNozzleCommand))
            {
                AddEditNozzleCommand detail = new();
               
                detail.Order = this.NozzlesCommand.Count==0?1: this.NozzlesCommand.OrderBy(x => x.Order).Last().Order + 1;
                detail.Name = $"N{detail.Order}";
                detail.ParentNozzles = this.NozzlesCommand;
                detail.EquipmentItemCommand = this;
                return (detail as T)!;
            }
            return null!;
        }
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
