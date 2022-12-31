using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate
{
    public class DownPaymentValidator : AbstractValidator<CommandDownPayment>
    {
        private readonly IRepositoryDownPayment _DownPaymentRepository;
        public DownPaymentValidator(IRepositoryDownPayment DownPaymentRepository)
        {
            _DownPaymentRepository = DownPaymentRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandDownPayment e, CancellationToken token)
        {
            return !await _DownPaymentRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
