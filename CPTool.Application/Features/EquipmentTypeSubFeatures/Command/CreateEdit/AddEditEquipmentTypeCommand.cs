using AutoMapper.Configuration.Annotations;
using CPtool.ExtensionMethods;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Command.CreateEdit
{

    public class AddEditEquipmentTypeSubCommand : AddEditCommand, IRequest<Result<AddEditEquipmentTypeSubCommand>>
    {
        public string TagLetter { get; set; } = string.Empty;
        public int EquipmentTypeId { get; set; }
    }
    internal class AddEditEquipmentTypeSubCommandHandler : IRequestHandler<AddEditEquipmentTypeSubCommand, Result<AddEditEquipmentTypeSubCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditEquipmentTypeCommand> _logger;

        public AddEditEquipmentTypeSubCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditEquipmentTypeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditEquipmentTypeSubCommand>> Handle(AddEditEquipmentTypeSubCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {
                var table = _mapper.Map<EquipmentTypeSub>(command);

                _unitOfWork.Repository<EquipmentTypeSub>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditEquipmentTypeSubCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(EquipmentTypeSub)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<EquipmentTypeSub>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditEquipmentTypeSubCommand), typeof(EquipmentTypeSub));

                    _unitOfWork.Repository<EquipmentTypeSub>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditEquipmentTypeSubCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(EquipmentTypeSub)}");
                }
                else
                {
                    return await Result<AddEditEquipmentTypeSubCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditEquipmentTypeSubCommandValidator : AbstractValidator<AddEditEquipmentTypeCommand>
    {
        public AddEditEquipmentTypeSubCommandValidator()
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
