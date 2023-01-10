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
        private readonly IRepositoryDownPayment _Repository;
        public DownPaymentValidator(IRepositoryDownPayment Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.DownpaymentName)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(p => p.CBSRequesText)
              .NotEmpty().WithMessage("CBS Request Text is required.")
              .NotNull().WithMessage("CBS Request Text is required.")
              .MaximumLength(50).WithMessage("CBS Request Text must not exceed 50 characters.");

            RuleFor(p => p.CBSRequesNo)
              .NotEmpty().WithMessage("CBS Reques No. is required.")
              .NotNull().WithMessage("CBS Reques No. is required.")
              .MaximumLength(50).WithMessage("CBS Reques No. must not exceed 50 characters.");

            RuleFor(p => p.ProformaInvoice)
            .NotEmpty().WithMessage("Proforma Invoice No. is required.")
            .NotNull().WithMessage("Proforma Invoice No. is required.")
            .MaximumLength(50).WithMessage("Proforma Invoice No. must not exceed 50 characters.");

            RuleFor(p => p.Payterms)
           .NotEmpty().WithMessage("Pay terms is required.")
           .NotNull().WithMessage("Pay terms is required.");

            RuleFor(p => p.DownpaymentDescrption)
            .NotEmpty().WithMessage("Description is required.")
            .NotNull().WithMessage("Description is required.");

            RuleFor(p => p.Incotherm)
           .NotEmpty().WithMessage("Incotherm is required.")
           .NotNull().WithMessage("Incotherm is required.");

            RuleFor(p => p.Percentage)
           .NotEqual(0).WithMessage("Percentage is required.")
           .GreaterThanOrEqualTo(100).WithMessage("Percentage must be less than 100.");

            RuleFor(customer => customer.ManagerEmail)
                .EmailAddress()
                .WithMessage("Eneter valida email adress.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandDownPayment e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.DownpaymentName == e.Name);
            return !result;
          
        }
    }
}
