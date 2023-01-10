using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class InstrumentItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItem _Repository;
        public InstrumentItemValidator(IRepositoryMWOItem Repository)
        {
            _Repository = Repository;
            RuleFor(p => p.MeasuredVariable!.Id)
             .NotEqual(0).WithMessage("Measured Variable is required.")
             .When(x => x.BudgetItem == false);



            RuleFor(p => p.TagNumber)
              .NotEmpty().WithMessage("Tag Number is required.")
               .NotNull().WithMessage("Tag Number is required.")
               .When(x => x.BudgetItem == false);

            RuleFor(e => e)
                .MustAsync(TagIdUnique)
                .WithMessage($"Tag Id already exists.")
                .When(x => x.BudgetItem == false);




        }


        private async Task<bool> TagIdUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;
           
            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.ChapterId == e.ChapterId && x.TagId == e.TagId);
            return !result;

        }
    }
}
