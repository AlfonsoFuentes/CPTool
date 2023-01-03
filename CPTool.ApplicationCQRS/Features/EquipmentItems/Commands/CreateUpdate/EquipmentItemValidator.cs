using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class EquipmentItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItemWithEquipment _RepositoryMWOItem;
        public EquipmentItemValidator(IRepositoryMWOItemWithEquipment RepositoryMWOItem)
        {
            _RepositoryMWOItem = RepositoryMWOItem;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.EquipmentItem!.eEquipmentType!.Id)
                .NotEqual(0).WithMessage("Equipment Type is required.");

            RuleFor(p => p.EquipmentItem!.TagNumber)
               .NotEmpty().WithMessage("Tag Number is required.")
                .NotNull().WithMessage("Tag Number is required.");

            RuleFor(e => e)
                 .MustAsync(TagNumber)
                 .WithMessage($"Tag Number already exists.");

            RuleFor(e => e)
                .MustAsync(NameUnique)
                .WithMessage($"Tag Id already exists.");

        }
        private async Task<bool> TagNumber(CommandMWOItem e, CancellationToken token)
        {
            if (e.EquipmentItem!.TagNumber == "") return true;
            var list = (await _RepositoryMWOItem.GetAllAsync(x => x.MWOId == e.MWOId && x.ChapterId == 4)).Select(x => x.EquipmentItem).ToImmutableList();
         
            return !list.Any(x => x!.TagNumber == e.EquipmentItem!.TagNumber);
        }


        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;
            var list = (await _RepositoryMWOItem.GetAllAsync(x => x.MWOId == e.MWOId && x.ChapterId == 4)).Select(y => y.EquipmentItem).ToImmutableList();
          

            return !list.Any(x => x!.TagId == e.TagId);
        }
    }
}
