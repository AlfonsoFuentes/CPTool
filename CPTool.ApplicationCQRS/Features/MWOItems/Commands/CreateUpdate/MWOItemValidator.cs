using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class MWOItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItem _Repository;
        public MWOItemValidator(IRepositoryMWOItem Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Chapter!.Id)
            .NotEqual(0).WithMessage("Chapter is required.");

            RuleFor(p => p.MWO!.Id)
         .NotEqual(0).WithMessage("MWO Name is required.");

            RuleFor(p => p.UnitaryBasePrizeId)
                .NotNull().WithMessage("Unitary Prize is required.")
        .NotEqual(0).WithMessage("Unitary Prize is required.")
        .When(p=>p.BudgetItem==true);

            RuleFor(p => p.BudgetPrize)
        .NotEqual(0).WithMessage("Budget in $USD is required.")
        .When(p => p.BudgetItem == true);

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
          
            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.Name == e.Name);
            return !result;
           
        }
    }
}
