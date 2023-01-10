using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class EquipmentItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItem _Repository;
        public EquipmentItemValidator(IRepositoryMWOItem Repository)
        {
            _Repository = Repository;



            RuleFor(p => p.EquipmentTypeId)
                .NotEqual(0).WithMessage("Equipment Type is required.")
                .When(x => x.BudgetItem == false);

            RuleFor(p => p.TagNumber)
               .NotEmpty().WithMessage("Tag Number is required.")
                .NotNull().WithMessage("Tag Number is required.")
                .When(x => x.BudgetItem == false);

            RuleFor(e => e)
                 .MustAsync(TagNumber)
                 .WithMessage($"Tag Number already exists.")

                .When(x => x.BudgetItem == false);


            RuleFor(e => e)
                .MustAsync(NameUnique)
                .WithMessage($"Tag Id already exists.")

                .When(x => x.BudgetItem == false);

        }
        private async Task<bool> TagNumber(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagNumber == "") return true;

            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.ChapterId == e.ChapterId && x.TagNumber == e.TagNumber);
            return !result;
           
        }


        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;
            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.ChapterId == e.ChapterId && x.TagId == e.TagId);
            return !result;
            
        }
    }
}
